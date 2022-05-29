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

  public bool[,] InitBoard(int num)
  {
    // init an 2D/multi-dimensional array with initial values of false to indicate empty space
    // note: multi-dimensional array doesn't support indexers/ranges,
    // however 2D array saves computing space as it's a single block of memory
    return new bool[num, num];
  }

  public IList<string> PrintBoard(bool[,] board)
  {
    int num = board.GetUpperBound(0) + 1;
    var printed = new List<string>();
    for (int i = 0; i < num; i++)
    {
      var row = "";
      for (int j = 0; j < num; j++)
      {
        row += board[i, j] ? QUEEN : EMPTY;
      }
      printed.Add(row);
    }
    return printed;
  }

  public bool IsAttacking(bool[,] board, int row, int col)
  {
    int num = board.GetUpperBound(0) + 1;
    for (int i = 0; i < num; i++)
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
      if (nextRow >= 0 && nextCol < num && board[nextRow, nextCol]) { return true; }
      // check down/left
      nextRow = row + i;
      nextCol = col - i;
      if (nextRow < num && nextCol >= 0 && board[nextRow, nextCol]) { return true; }
      // check down/right
      // nextRow = row + i;
      nextCol = col + i;
      if (nextRow < num && nextCol < num && board[nextRow, nextCol]) { return true; }
    }
    return false;
  }

  public int PlaceQueens(bool[,] board, int row, int col)
  {
    int num = board.GetUpperBound(0) + 1;
    // place the 1st queen at the given position
    board[row, col] = true;
    int queens = 1;

    for (int i = row * num + col + 1; i < num * num; i++)
    {
      int nextCow = i / num;
      int nextRow = i % num;
      if (!IsAttacking(board, nextCow, nextRow))
      {
        board[nextCow, nextRow] = true;
        queens++;
        if (queens == num)
        {
          break;
        }
      }
    }
    return queens;
  }

  public IList<IList<string>> SolveNQueens(int n)
  {
    var solutions = new List<IList<string>>();

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        var board = InitBoard(n);
        if (n == PlaceQueens(board, i, j))
        {
          solutions.Add(PrintBoard(board));
        }
      }
    }

    return solutions;
  }
}
