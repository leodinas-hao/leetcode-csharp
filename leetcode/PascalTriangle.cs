/*
Pascal's Triangle
https://leetcode.com/problems/pascals-triangle/

Given an integer numRows, return the first numRows of Pascal's triangle.
In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

Example 2:
Input: numRows = 1
Output: [[1]]
 

Constraints:
1 <= numRows <= 30
*/

namespace LeetCode.PascalTriangle;

public class Solution
{
  public IList<IList<int>> Generate(int numRows)
  {
    var ans = new int[numRows][];
    ans[0] = new int[] { 1 };

    for (int i = 1; i < numRows; i++)
    {
      ans[i] = new int[i + 1];
      ans[i][0] = 1;
      ans[i][^1] = 1;
      for (int j = 1; j < i; j++)
      {
        ans[i][j] = ans[i - 1][j] + ans[i - 1][j - 1];
      }
    }

    return ans;
  }
}