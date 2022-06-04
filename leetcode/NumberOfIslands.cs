/*
Number of Islands
https://leetcode.com/problems/number-of-islands/

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/

namespace LeetCode.NumberOfIslands;

public class Solution
{
  // dfs search the grid and change islands '1' to '0'
  private void Search(char[][] grid, int r, int c)
  {
    if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == '0')
    {
      return;
    }
    // change the island to water
    grid[r][c] = '0';
    // dfs search all associated island and make them water
    Search(grid, r - 1, c);
    Search(grid, r + 1, c);
    Search(grid, r, c - 1);
    Search(grid, r, c + 1);
  }

  public int NumIslands(char[][] grid)
  {
    int count = 0;
    for (int r = 0; r < grid.Length; r++)
    {
      for (int c = 0; c < grid[0].Length; c++)
      {
        if (grid[r][c] == '1')
        {
          count++;
          Search(grid, r, c);
        }
      }
    }
    return count;
  }
}
