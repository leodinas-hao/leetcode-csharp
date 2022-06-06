/*
Number of enclaves
https://leetcode.com/problems/number-of-enclaves/

You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents a land cell.

A move consists of walking from one land cell to another adjacent (4-directionally) land cell or walking off the boundary of the grid.

Return the number of land cells in grid for which we cannot walk off the boundary of the grid in any number of moves.

Example 1:
Input: grid = [
  [0,0,0,0],
  [1,0,1,0],
  [0,1,1,0],
  [0,0,0,0]
]
Output: 3
Explanation: There are three 1s that are enclosed by 0s, and one 1 that is not enclosed because its on the boundary.

Example 2:
Input: grid = [
  [0,1,1,0],
  [0,0,1,0],
  [0,0,1,0],
  [0,0,0,0]
]
Output: 0
Explanation: All 1s are either on the boundary or can reach the boundary.

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 500
grid[i][j] is either 0 or 1.
*/

namespace LeetCode.NumberOfEnclaves;

public class Solution
{
  private void Search(int[][] grid, int r, int c)
  {
    if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == 0)
    {
      return;
    }

    grid[r][c] = 0;

    Search(grid, r - 1, c);
    Search(grid, r + 1, c);
    Search(grid, r, c - 1);
    Search(grid, r, c + 1);
  }

  public int NumEnclaves(int[][] grid)
  {
    // iterate the grid to remove all 1's connected to the boundary
    for (int r = 0; r < grid.Length; r++)
    {
      for (int c = 0; c < grid[0].Length; c++)
      {
        if ((r == 0 || c == 0 || r == grid.Length - 1 || c == grid[0].Length - 1) && grid[r][c] == 1)
        {
          Search(grid, r, c);
        }
      }
    }

    // count 1's in the grid
    return grid.Select(r => r.Sum()).Sum();
  }
}
