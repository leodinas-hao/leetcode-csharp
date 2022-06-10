/*
Count Negative Numbers in a Sorted Matrix
https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/

Given a m x n matrix grid which is sorted in non-increasing order both row-wise and column-wise, return the number of negative numbers in grid.

Example 1:
Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
Output: 8
Explanation: There are 8 negatives number in the matrix.

Example 2:
Input: grid = [[3,2],[1,0]]
Output: 0

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 100
-100 <= grid[i][j] <= 100

Follow up: Could you find an O(n + m) solution?
*/


namespace LeetCode.CountNegativeNumbersInASortedMatrix;

public class Solution
{
  private int GetFirstNegative(int[] arr, int lo, int hi)
  {
    // BFS to locate the first negative number in the array
    while (lo <= hi)
    {
      int mid = lo + (hi - lo) / 2;
      if (arr[mid] < 0) hi = mid - 1;
      else lo = mid + 1;
    }
    // return the index of the first negative number
    if (lo < arr.Length && arr[lo] < 0) return lo;
    // if no negative number found, return -1
    return -1;
  }

  public int CountNegatives(int[][] grid)
  {
    int rows = grid.Length, cols = grid[0].Length;
    int count = 0;
    int lo = 0, hi = cols - 1;
    foreach (var arr in grid)
    {
      hi = GetFirstNegative(arr, lo, hi);
      // if no negative found, reset next search to end of array
      // otherwise next search will be optimized
      if (hi < 0) hi = cols - 1;
      else count += cols - hi;
    }
    return count;
  }
}
