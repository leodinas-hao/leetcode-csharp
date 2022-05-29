/*
N Queens
https://leetcode.com/problems/n-queens/

The n-queens puzzle is the problem of placing n queens on an n x n chessboard
such that no two queens attack each other.
Given an integer n, return all distinct solutions to the n-queens puzzle.
You may return the answer in any order.
Each solution contains a distinct board configuration of the n-queens' placement,
where 'Q' and '.' both indicate a queen and an empty space, respectively.
Note: The queen can be moved any number of unoccupied squares in a straight line vertically, horizontally, or diagonally

Example 1:
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

Example 2:
Input: n = 1
Output: [["Q"]]

Example 5:
Input: n = 5
Output: 
[
  ["Q....","..Q..","....Q",".Q...","...Q."],["Q....","...Q.",".Q...","....Q","..Q.."],
  [".Q...","...Q.","Q....","..Q..","....Q"],[".Q...","....Q","..Q..","Q....","...Q."],
  ["..Q..","Q....","...Q.",".Q...","....Q"],["..Q..","....Q",".Q...","...Q.","Q...."],
  ["...Q.","Q....","..Q..","....Q",".Q..."],["...Q.",".Q...","....Q","..Q..","Q...."],
  ["....Q",".Q...","...Q.","Q....","..Q.."],["....Q","..Q..","Q....","...Q.",".Q..."]
]

Constraints:
1 <= n <= 9
*/

namespace LeetCode.NQueens;

public class Solution
{
  public const string QUEEN = "Q";
  public const string EMPTY = ".";

  // keep a reference of board size
  // to avoid recalculating/keeping passing the variable
  // to calculate the board size from board: `board.GetUpperBound(0) + 1`
  private int size = 0;
  public bool[,] InitBoard(int size)
  {
    // init an 2D/multi-dimensional array with initial values of false to indicate empty space
    // note: multi-dimensional array doesn't support indexers/ranges,
    // however 2D array saves computing space as it's a single block of memory
    this.size = size;
    return new bool[size, size];
  }

  public IList<string> PrintBoard(bool[,] board)
  {
    var printed = new List<string>();
    for (int i = 0; i < size; i++)
    {
      var row = "";
      for (int j = 0; j < size; j++)
      {
        row += board[i, j] ? QUEEN : EMPTY;
      }
      printed.Add(row);
    }
    return printed;
  }

  public bool IsAttacked(bool[,] board, int row, int col)
  {
    // check vertically, horizontally, or diagonally to see if
    // the position is attacked by another queen
    for (int i = 0; i < size; i++)
    {
      // check horizontal
      if (board[row, i]) { return true; }
      // check vertical
      if (board[i, col]) { return true; }
      int nextRow, nextCol;
      // check up/left
      nextRow = row - i;
      nextCol = col - i;
      if (nextRow >= 0 && nextCol >= 0 && board[nextRow, nextCol]) { return true; }
      // check up/right
      // nextRow = row - i;
      nextCol = col + i;
      if (nextRow >= 0 && nextCol < size && board[nextRow, nextCol]) { return true; }
      // check down/left
      nextRow = row + i;
      nextCol = col - i;
      if (nextRow < size && nextCol >= 0 && board[nextRow, nextCol]) { return true; }
      // check down/right
      // nextRow = row + i;
      nextCol = col + i;
      if (nextRow < size && nextCol < size && board[nextRow, nextCol]) { return true; }
    }
    return false;
  }

  public void Solve(IList<IList<string>> solutions, bool[,] board, int col)
  {
    if (col == size)
    {
      // when processed all columns, it's a valid solution
      solutions.Add(PrintBoard(board));
      return;
    }

    for (int row = 0; row < size; row++)
    {
      if (!IsAttacked(board, row, col))
      {
        // it's a safe position, place a queen
        board[row, col] = true;
        // process next column
        Solve(solutions, board, col + 1);
        // if reached here, no valid solution found
        // removed the last placed queen
        board[row, col] = false;
      }
    }
  }

  public IList<IList<string>> SolveNQueens(int n)
  {
    var solutions = new List<IList<string>>();
    var board = InitBoard(n);
    Solve(solutions, board, 0);
    return solutions;
  }
}
