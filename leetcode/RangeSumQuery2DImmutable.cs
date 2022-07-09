/*
Range Sum Query 2D - Immutable
https://leetcode.com/problems/range-sum-query-2d-immutable/

Given a 2D matrix matrix, handle multiple queries of the following type:

Calculate the sum of the elements of matrix inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
Implement the NumMatrix class:

NumMatrix(int[][] matrix) Initializes the object with the integer matrix matrix.
int sumRegion(int row1, int col1, int row2, int col2) Returns the sum of the elements of matrix inside the rectangle defined 
by its upper left corner (row1, col1) and lower right corner (row2, col2).

Example 1:
Input
["NumMatrix", "sumRegion", "sumRegion", "sumRegion"]
[[[[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]], [2, 1, 4, 3], [1, 1, 2, 2], [1, 2, 2, 4]]
Output
[null, 8, 11, 12]
Explanation
NumMatrix numMatrix = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
numMatrix.sumRegion(2, 1, 4, 3); // return 8 (i.e sum of the red rectangle)
numMatrix.sumRegion(1, 1, 2, 2); // return 11 (i.e sum of the green rectangle)
numMatrix.sumRegion(1, 2, 2, 4); // return 12 (i.e sum of the blue rectangle)

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 200
-10^4 <= matrix[i][j] <= 10^4
0 <= row1 <= row2 < m
0 <= col1 <= col2 < n
At most 104 calls will be made to sumRegion.
*/

namespace LeetCode.RangeSumQuery2DImmutable;

/*
use dp to pre-compute a cumulative region sum with respect to the origin at (0,0)
|o       |
|   a b  |
|        |
|   c d  |
|        |

Sum(abcd) = Sum(od) - Sum(ob) - Sum(oc) + Sum(oa)
*/
public class NumMatrix
{
  private int[][] dp;

  public NumMatrix(int[][] matrix)
  {
    dp = new int[matrix.Length + 1][];
    for (int i = 0; i < dp.Length; i++)
    {
      dp[i] = new int[matrix[0].Length + 1];
    }
    for (int r = 0; r < matrix.Length; r++)
    {
      for (int c = 0; c < matrix[0].Length; c++)
      {
        dp[r + 1][c + 1] = dp[r + 1][c] + dp[r][c + 1] + matrix[r][c] - dp[r][c];
      }
    }
  }

  public int SumRegion(int row1, int col1, int row2, int col2)
  {
    return dp[row2 + 1][col2 + 1] - dp[row1][col2 + 1] - dp[row2 + 1][col1] + dp[row1][col1];
  }
}
