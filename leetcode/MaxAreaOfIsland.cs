/*
Max Area of Island
https://leetcode.com/problems/max-area-of-island/

You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) 
You may assume all four edges of the grid are surrounded by water.
The area of an island is the number of cells with a value 1 in the island.
Return the maximum area of an island in grid. If there is no island, return 0.

Example 1:
0-0-1-0-0-0-0-1-0-0-0-0-0
0-0-0-0-0-0-0-1-1-1-0-0-0
0-1-1-0-1-0-0-0-0-0-0-0-0
0-1-0-0-1-1-0-0-1-0-1-0-0
0-1-0-0-1-1-0-0-1-1-1-0-0
0-0-0-0-0-0-0-0-0-0-1-0-0
0-0-0-0-0-0-0-1-1-1-0-0-0
0-0-0-0-0-0-0-1-1-0-0-0-0

Input: grid = [
  [0,0,1,0,0,0,0,1,0,0,0,0,0],
  [0,0,0,0,0,0,0,1,1,1,0,0,0],
  [0,1,1,0,1,0,0,0,0,0,0,0,0],
  [0,1,0,0,1,1,0,0,1,0,1,0,0],
  [0,1,0,0,1,1,0,0,1,1,1,0,0],
  [0,0,0,0,0,0,0,0,0,0,1,0,0],
  [0,0,0,0,0,0,0,1,1,1,0,0,0],
  [0,0,0,0,0,0,0,1,1,0,0,0,0]
]
Output: 6
Explanation: The answer is not 11, because the island must be connected 4-directionally.

Example 2:
Input: grid = [[0,0,0,0,0,0,0,0]]
Output: 0

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 50
grid[i][j] is either 0 or 1.
*/

namespace LeetCode.MaxAreaOfIsland;

public class Solution
{
  public int CountIslands(int[][] grid, int r, int c)
  {
    if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == 0)
    {
      return 0;
    }
    // change to water to avoid recount
    grid[r][c] = 0;
    // count the 4 directions
    return (1 + CountIslands(grid, r, c + 1) +
                CountIslands(grid, r, c - 1) +
                CountIslands(grid, r + 1, c) +
                CountIslands(grid, r - 1, c)
    );
  }

  public int MaxAreaOfIsland(int[][] grid)
  {
    int max = 0, count;
    for (int r = 0; r < grid.Length; r++)
    {
      for (int c = 0; c < grid[0].Length; c++)
      {
        if (grid[r][c] == 1)
        {
          count = CountIslands(grid, r, c);
          max = Math.Max(max, count);
        }
      }
    }
    return max;
  }
}
