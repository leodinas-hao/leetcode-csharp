/*
Maximal Square
https://leetcode.com/problems/maximal-square/

Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

Example 1:
Input: matrix = [
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
Output: 4
Explain: square matrix[1][2] to matrix[2][3] sum as 4; also square between matrix[1][3] to matrix[2][4]

Example 2:
Input: matrix = [
  ["0","1"],
  ["1","0"]
]
Output: 1
Explain: square with just one cell matrix[0][1] sum as 1; also  square with just one cell matrix[1][0] sum as 1

Example 3:
Input: matrix = [["0"]]
Output: 0

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 300
matrix[i][j] is '0' or '1'.
*/

namespace LeetCode.MaximalSquare;

/*
brute force
*/
public class Solution
{
  public int MaximalSquare(char[][] matrix)
  {
    int rows = matrix.Length, cols = rows > 0 ? matrix[0].Length : 0;
    int maxLen = 0;

    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        if (matrix[i][j] == '1')
        {
          int len = 1;
          bool flag = true;
          while (len + i < rows && len + j < cols && flag)
          {
            for (int k = j; k <= len + j; k++)
            {
              if (matrix[i + len][k] == '0')
              {
                flag = false;
                break;
              }
            }
            for (int k = i; k <= len + i; k++)
            {
              if (matrix[k][j + len] == '0')
              {
                flag = false;
                break;
              }
            }
            if (flag) len++;
          }
          maxLen = Math.Max(len, maxLen);
        }
      }
    }

    return maxLen * maxLen;
  }
}

/*
dp
*/
public class Solution2
{
  public int MaximalSquare(char[][] matrix)
  {
    int rows = matrix.Length, cols = rows > 0 ? matrix[0].Length : 0;
    int[] dp = new int[cols + 1];
    int maxLen = 0, prev = 0;
    for (int i = 1; i <= rows; i++)
    {
      for (int j = 1; j <= cols; j++)
      {
        int temp = dp[j];
        if (matrix[i - 1][j - 1] == '1')
        {
          dp[j] = Math.Min(Math.Min(dp[j - 1], prev), dp[j]) + 1;
          maxLen = Math.Max(maxLen, dp[j]);
        }
        else
        {
          dp[j] = 0;
        }
        prev = temp;
      }
    }
    return maxLen * maxLen;
  }
}