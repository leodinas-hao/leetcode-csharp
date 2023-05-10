/*
Spiral Matrix II
https://leetcode.com/problems/spiral-matrix-ii/

Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.

Example 1:
Input: n = 3
Output: [
  [1,2,3],
  [8,9,4],
  [7,6,5]
]

Example 2:
Input: n = 1
Output: [[1]]

Constraints:
1 <= n <= 20
*/

namespace LeetCode.SpiralMatrixII;

public class Solution
{
  public int[][] GenerateMatrix(int n)
  {
    var matrix = new int[n][];
    for (int i = 0; i < n; i++)
    {
      matrix[i] = new int[n];
    }

    var dir = new int[][]{
      new int[] { 0, 1 },  // go right
      new int[] { 1, 0 },  // go down
      new int[] { 0, -1 },  // go left
      new int[] { -1, 0 },  // to up
    };

    int dc = 0, row = 0, col = 0;

    for (int i = 0; i < n * n; i++)
    {
      matrix[row][col] = i + 1;

      var next_row = dir[dc][0] + row;
      var next_col = dir[dc][1] + col;

      if (next_row < 0 || next_col < 0 || next_row >= n || next_col >= n || matrix[next_row][next_col] != 0)
      {
        dc = (dc + 1) % 4;
        row += dir[dc][0];
        col += dir[dc][1];
      }
      else
      {
        row = next_row;
        col = next_col;
      }
    }

    return matrix;
  }
}
