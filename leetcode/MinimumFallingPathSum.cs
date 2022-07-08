/*
Minimum falling path sum
https://leetcode.com/problems/minimum-falling-path-sum/

Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.

A falling path starts at any element in the first row and chooses the element in the next row 
that is either directly below or diagonally left/right. Specifically, 
the next element from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).

Example 1:

2 1 3            2  [1] 3           2  [1] 3
6 5 4    -->     6  [5] 4     or    6   5 [4]
7 8 9            [7] 8  9           7  [8] 9

Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
Output: 13
Explanation: There are two falling paths with a minimum sum as shown.

Example 2:
-19  57          [-19]  57
-40  -5   -->    [-40]  -5

Input: matrix = [[-19,57],[-40,-5]]
Output: -59
Explanation: The falling path with a minimum sum is shown.

Constraints:
n == matrix.length == matrix[i].length
1 <= n <= 100
-100 <= matrix[i][j] <= 100
*/

namespace LeetCode.MinimumFallingPathSum;

public class Solution
{
  public int MinFallingPathSum(int[][] matrix)
  {
    int n = matrix.Length;
    if (n == 1) return matrix[0][0];

    int[][] dp = new int[n][];
    for (int i = 0; i < n; i++)
    {
      dp[i] = new int[n];
      dp[0][i] = matrix[0][i];
    }

    for (int i = 1; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        int cl = j == 0 ? 0 : j - 1;
        int cr = j == n - 1 ? j : j + 1;
        dp[i][j] = Math.Min(dp[i - 1][j], Math.Min(dp[i - 1][cl], dp[i - 1][cr])) + matrix[i][j];
      }
    }

    return dp[n - 1].Min();
  }
}
