/*
Squares of a Sorted Array
https://leetcode.com/problems/squares-of-a-sorted-array/

Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

Example 1:
Input: nums = [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Explanation: After squaring, the array becomes [16,1,0,9,100].
After sorting, it becomes [0,1,9,16,100].

Example 2:
Input: nums = [-7,-3,2,3,11]
Output: [4,9,9,49,121]

Constraints:

1 <= nums.length <= 10^4
-10^4 <= nums[i] <= 10^4
nums is sorted in non-decreasing order.
*/

namespace LeetCode.SquaresOfASortedArray;


public class Solution
{
  public int[] SortedSquares(int[] nums)
  {
    int n = nums.Length;
    int[] sqrs = new int[n];
    int start = 0, end = n - 1, curr = n - 1;
    while (start <= end)
    {
      if (Math.Abs(nums[start]) > Math.Abs(nums[end]))
      {
        sqrs[curr] = nums[start] * nums[start];
        start++;
      }
      else
      {
        sqrs[curr] = nums[end] * nums[end];
        end--;
      }
      curr--;
    }
    return sqrs;
  }
}

public class Solution2
{
  public int[] SortedSquares(int[] nums)
  {
    return nums.Select(n => n * n).OrderBy(n => n).ToArray();
  }
}
