/*
Number of closed islands
https://leetcode.com/problems/number-of-closed-islands/

Given a 2D grid consists of 0s (land) and 1s (water).  An island is a maximal 4-directionally connected group of 0s and 
a closed island is an island totally (all left, top, right, bottom) surrounded by 1s.

Return the number of closed islands.

Example 1:
Input: grid = [
  [1,1,1,1,1,1,1,0],
  [1,0,0,0,0,1,1,0],
  [1,0,1,0,1,1,1,0],
  [1,0,0,0,0,1,0,1],
  [1,1,1,1,1,1,1,0]
]
Output: 2
Explanation: 
Islands in gray are closed because they are completely surrounded by water (group of 1s).

Example 2:
Input: grid = [
  [0,0,1,0,0],
  [0,1,0,1,0],
  [0,1,1,1,0]
]
Output: 1

Example 3:
Input: grid = [
  [1,1,1,1,1,1,1],
  [1,0,0,0,0,0,1],
  [1,0,1,1,1,0,1],
  [1,0,1,0,1,0,1],
  [1,0,1,1,1,0,1],
  [1,0,0,0,0,0,1],
  [1,1,1,1,1,1,1]
]
Output: 2

Constraints:
1 <= grid.length, grid[0].length <= 100
0 <= grid[i][j] <=1
*/

namespace LeetCode.NumberOfClosedIslands;

public class Solution
{
  public bool IsClosedIsland(int[][] grid, int r, int c)
  {
    if (grid[r][c] == 1) return true;

    if (r <= 0 || c <= 0 || r >= grid.Length - 1 || c >= grid[0].Length - 1)
    {
      return false;
    }

    grid[r][c] = 1;

    var down = IsClosedIsland(grid, r + 1, c);
    var up = IsClosedIsland(grid, r - 1, c);
    var right = IsClosedIsland(grid, r, c + 1);
    var left = IsClosedIsland(grid, r, c - 1);

    return down && up && right && left;
  }
  public int ClosedIsland(int[][] grid)
  {
    int count = 0;
    for (int r = 1; r < grid.Length - 1; r++)
    {
      for (int c = 1; c < grid[0].Length - 1; c++)
      {
        if (grid[r][c] == 0 && IsClosedIsland(grid, r, c))
        {
          count++;
        }
      }
    }
    return count;
  }
}
