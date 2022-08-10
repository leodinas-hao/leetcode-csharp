/*
Surrounded Regions
https://leetcode.com/problems/surrounded-regions/

Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'.
A region is captured by flipping all 'O's into 'X's in that surrounded region.

Example 1:
Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
Explanation: Notice that an 'O' should not be flipped if:
- It is on the border, or
- It is adjacent to an 'O' that should not be flipped.
The bottom 'O' is on the border, so it is not flipped.
The other three 'O' form a surrounded region, so they are flipped.

Example 2:
Input: board = [["X"]]
Output: [["X"]]

Constraints:
m == board.length
n == board[i].length
1 <= m, n <= 200
board[i][j] is 'X' or 'O'.
*/

namespace LeetCode.SurroundedRegions;

/*
DFS solution
recursively checking the middle cells surroundings to confirm it can be flipped to 'X'
however this approach will exceed time limit on LeetCode when processing big matrix
*/
public class Solution
{
  private bool CanFlip(char[][] board, int r, int c, IList<(int, int)> visited)
  {
    if (board[r][c] == 'X') return true;

    // reached the edge (not meeting a 'X')
    if (r == 0 || c == 0 || r == board.Length - 1 || c == board[0].Length - 1) return false;

    // mark the cell as visited
    visited.Add((r, c));

    // check surrounding cells
    var up = visited.Contains((r - 1, c)) ? true : CanFlip(board, r - 1, c, visited);
    var down = visited.Contains((r + 1, c)) ? true : CanFlip(board, r + 1, c, visited);
    var left = visited.Contains((r, c - 1)) ? true : CanFlip(board, r, c - 1, visited);
    var right = visited.Contains((r, c + 1)) ? true : CanFlip(board, r, c + 1, visited);
    return up && down && left && right;
  }

  public void Solve(char[][] board)
  {
    for (int r = 1; r < board.Length - 1; r++)
    {
      for (int c = 1; c < board[0].Length - 1; c++)
      {
        if (board[r][c] == 'O')
        {
          if (CanFlip(board, r, c, new List<(int, int)>())) board[r][c] = 'X';
        }
      }
    }
  }
}


/*
DFS solution
instead of checking the cells in the middle
check if any cells on the edge that is 'O', then DFS mark all its surrounding cells to '#';
then iterate the matrix, flip any cells: '#' -> 'O'; otherwise (if 'O') -> 'X'
*/
public class Solution2
{
  // DFS to check edge cell 'O' surroundings
  private void Helper(char[][] board, int r, int c)
  {
    if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length) return;
    if (board[r][c] != 'O') return;

    board[r][c] = '#';
    Helper(board, r + 1, c);
    Helper(board, r - 1, c);
    Helper(board, r, c + 1);
    Helper(board, r, c - 1);
  }

  public void Solve(char[][] board)
  {
    int rows = board.Length, cols = board[0].Length;
    for (int r = 0; r < rows; r++)
    {
      for (int c = 0; c < cols; c++)
      {
        if (board[r][c] == 'O' && (r == 0 || c == 0 || r == rows - 1 || c == cols - 1)) Helper(board, r, c);
      }
    }

    for (int r = 0; r < rows; r++)
    {
      for (int c = 0; c < cols; c++)
      {
        if (board[r][c] == '#') board[r][c] = 'O';
        else board[r][c] = 'X';
      }
    }
  }
}