/*
Maximum Side Length of a Square with Sum Less than or Equal to Threshold
https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/

Given a m x n matrix mat and an integer threshold, return the maximum side-length of 
a square with a sum less than or equal to threshold or return 0 if there is no such square.

Example 1:
Input: mat = [[1,1,3,2,4,3,2],[1,1,3,2,4,3,2],[1,1,3,2,4,3,2]], threshold = 4
Output: 2
Explanation: The maximum side length of square with sum less than 4 is 2 as shown.

Example 2:
Input: mat = [[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2]], threshold = 1
Output: 0

Constraints:
m == mat.length
n == mat[i].length
1 <= m, n <= 300
0 <= mat[i][j] <= 10^4
0 <= threshold <= 10^5
*/

namespace LeetCode.MaximumSideLengthOfASquareWithSumLessThanOrEqualToThreshold;

public class Solution
{
  private bool Check(int[,] sums, int threshold, int rows, int cols, int size)
  {
    for (int r = size; r <= rows; r++)
    {
      for (int c = size; c <= cols; c++)
      {
        int sum = sums[r, c] - sums[r - size, c] - sums[r, c - size] + sums[r - size, c - size];
        if (sum <= threshold) return true;
      }
    }
    return false;
  }

  public int MaxSideLength(int[][] mat, int threshold)
  {
    int rows = mat.Length, cols = mat[0].Length;
    int[,] preSum = new int[rows + 1, cols + 1];
    for (int i = 1; i <= rows; i++)
    {
      for (int j = 1; j <= cols; j++)
      {
        preSum[i, j] = preSum[i - 1, j] + preSum[i, j - 1] - preSum[i - 1, j - 1] + mat[i - 1][j - 1];
      }
    }

    int lo = 1, hi = Math.Min(cols, rows);
    while (lo <= hi)
    {
      int mid = (lo + hi) / 2;
      if (Check(preSum, threshold, rows, cols, mid)) lo = mid + 1;
      else hi = mid - 1;
    }
    return lo - 1;
  }
}