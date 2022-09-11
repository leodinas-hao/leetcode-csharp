/*
Find a Peak Element II
https://leetcode.com/problems/find-a-peak-element-ii/

A peak element in a 2D grid is an element that is strictly greater than all of its adjacent neighbors to the left, right, top, and bottom.
Given a 0-indexed m x n matrix mat where no two adjacent cells are equal, find any peak element mat[i][j] and return the length 2 array [i,j].
You may assume that the entire matrix is surrounded by an outer perimeter with the value -1 in each cell.
You must write an algorithm that runs in O(m log(n)) or O(n log(m)) time.

Example 1:
-1 -1 -1 -1
-1  1  4 -1
-1  3  2 -1
-1 -1 -1 -1
Input: mat = [[1,4],[3,2]]
Output: [0,1]
Explanation: Both 3 and 4 are peak elements so [1,0] and [0,1] are both acceptable answers.

Example 2:
-1 -1 -1 -1 -1
-1 10 20 15 -1
-1 21 30 14 -1
-1  7 16 32 -1
-1 -1 -1 -1 -1
Input: mat = [[10,20,15],[21,30,14],[7,16,32]]
Output: [1,1]
Explanation: Both 30 and 32 are peak elements so [1,1] and [2,2] are both acceptable answers.

Constraints:
m == mat.length
n == mat[i].length
1 <= m, n <= 500
1 <= mat[i][j] <= 10^5
No two adjacent cells are equal.
*/

namespace LeetCode.FindAPeakElementII;

/*
two pointer
*/
public class Solution
{
  public int[] FindPeakGrid(int[][] mat)
  {
    int[] ans = new int[2] { -1, -1 };
    int rows = mat.Length, cols = mat[0].Length;
    int max = 1; // given constraints
    if (rows == 1 && cols == 1) return new int[2] { 0, 0 };

    for (int i = 0; i < rows; i++)
    {
      int lo = 0, hi = cols - 1;
      while (lo <= hi)
      {
        if (mat[i][lo] >= max)
        {
          ans[0] = i;
          ans[1] = lo;
          max = mat[i][lo];
        }
        if (mat[i][hi] >= max)
        {
          ans[0] = i;
          ans[1] = hi;
          max = mat[i][hi];
        }
        lo++;
        hi--;
      }
    }
    return ans;
  }
}

/*
binary search
*/
public class Solution2
{
  private int GetMaxIndex(int[] nums)
  {
    int max = 0;
    for (int i = 1; i < nums.Length; i++)
    {
      if (nums[i] > nums[max]) max = i;
    }
    return max;
  }

  public int[] FindPeakGrid(int[][] mat)
  {
    if (mat.Length == 1 && mat[0].Length == 1) return new int[2] { 0, 0 };

    int startRow = 0, endRow = mat.Length - 1;
    while (startRow <= endRow)
    {
      int midRow = (startRow + endRow) / 2;
      int rowMax = GetMaxIndex(mat[midRow]);

      int curMax = mat[midRow][rowMax];

      // if first row
      if (midRow == 0)
      {
        if (curMax > mat[midRow + 1][rowMax]) return new int[] { midRow, rowMax };
        else startRow = midRow + 1;
      }
      // if last row
      else if (midRow == mat.Length - 1)
      {
        if (curMax > mat[midRow - 1][rowMax]) return new int[] { midRow, rowMax };
        else endRow = midRow - 1;
      }
      // if not last/first
      else
      {
        if (curMax > mat[midRow + 1][rowMax] && curMax > mat[midRow - 1][rowMax])
          return new int[] { midRow, rowMax };
        else
        {
          // not peak, move to other rows
          if (curMax < mat[midRow + 1][rowMax]) startRow = midRow + 1;
          else endRow = midRow - 1;
        }
      }
    }
    // no peak found
    return new int[] { -1, -1 };
  }
}
