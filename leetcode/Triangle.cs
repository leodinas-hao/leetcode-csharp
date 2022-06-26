/*
Triangle
https://leetcode.com/problems/triangle/

Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below.
More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

Example 1:
Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

Example 2:
Input: triangle = [[-10]]
Output: -10

Example 3:
  -1
 2  3
1 -1 -3

Input: [[-1],[2,3],[1,-1,-3]]
Output: -1
Minimum path: -1 + 3 + -3 = -1

Constraints:
1 <= triangle.length <= 200
triangle[0].length == 1
triangle[i].length == triangle[i - 1].length + 1
-10^4 <= triangle[i][j] <= 10^4

Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?
*/

namespace LeetCode.Triangle;

public class Solution
{
  public int MinimumTotal(IList<IList<int>> triangle)
  {
    int size = triangle.Count;
    if (size == 1) return triangle[0][0];

    // iterate from the 2nd bottom to up
    for (int i = size - 2; i > -1; i--)
    {
      for (int j = 0; j < triangle[i].Count; j++)
      {
        // add the minimum of lower level cell to this one
        // update the existing triangle without additional storage
        triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
      }
    }
    return triangle[0][0];
  }
}
