/*
Minimum Path Sum
https://leetcode.com/problems/minimum-path-sum/

Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example 1:
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

Example 2:
Input: grid = [[1,2,3],[4,5,6]]
Output: 12

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 200
0 <= grid[i][j] <= 100
*/

namespace LeetCode.MinimumPathSum;

public class Solution
{
  public int MinPathSum(int[][] grid)
  {
    int rows = grid.Length, cols = grid[0].Length;

    for (int r = 0; r < rows; r++)
    {
      for (int c = 0; c < cols; c++)
      {
        if (r == 0 && c == 0) continue;
        else if (r == 0) grid[r][c] += grid[r][c - 1];
        else if (c == 0) grid[r][c] += grid[r - 1][c];
        else grid[r][c] += Math.Min(grid[r - 1][c], grid[r][c - 1]);
      }
    }

    return grid[rows - 1][cols - 1];
  }
}