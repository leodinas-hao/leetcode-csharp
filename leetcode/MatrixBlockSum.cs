/*
matrix block sum
https://leetcode.com/problems/matrix-block-sum/

Given a m x n matrix mat and an integer k, return a matrix answer where each answer[i][j] is the sum of all elements mat[r][c] for:
i - k <= r <= i + k,
j - k <= c <= j + k, and
(r, c) is a valid position in the matrix.

Example 1:
Input: mat = [[1,2,3],[4,5,6],[7,8,9]], k = 1
Output: [[12,21,16],[27,45,33],[24,39,28]]

Example 2:
Input: mat = [[1,2,3],[4,5,6],[7,8,9]], k = 2
Output: [[45,45,45],[45,45,45],[45,45,45]]

Constraints:
m == mat.length
n == mat[i].length
1 <= m, n, k <= 100
1 <= mat[i][j] <= 100
*/

namespace LeetCode.MatrixBlockSum;

/*
similar to RangeSumQuery2DImmutable
*/
public class Solution
{
  public int[][] MatrixBlockSum(int[][] mat, int k)
  {
    int[,] dp = new int[mat.Length + 1, mat[0].Length + 1];
    for (int i = 1; i <= mat.Length; i++)
    {
      for (int j = 1; j <= mat[0].Length; j++)
      {
        int x = i - 1;
        int y = j - 1;
        dp[i, j] = dp[x, j] + dp[i, y] + mat[x][y] - dp[x, y];
      }
    }

    for (int i = 0; i < mat.Length; i++)
    {
      for (int j = 0; j < mat[i].Length; j++)
      {
        int r1 = Math.Max(0, i - k);
        int c1 = Math.Max(0, j - k);
        int r2 = Math.Min(mat.Length - 1, i + k);
        int c2 = Math.Min(mat[0].Length - 1, j + k);

        int x = r2 + 1;
        int y = c2 + 1;

        mat[i][j] = dp[x, y] - dp[r1, y] - dp[x, c1] + dp[r1, c1];
      }
    }

    return mat;
  }
}