/*
Find First and Last Position of Element in Sorted Array
https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]

Example 2:
Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]

Example 3:
Input: nums = [], target = 0
Output: [-1,-1]

Constraints:
0 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9
nums is a non-decreasing array.
-10^9 <= target <= 10^9
*/

namespace LeetCode.FindFirstAndLastPositionOfElementInSortedArray;

public class Solution
{
  private int[] Search(int[] nums, int target, int lo, int hi)
  {
    while (lo < hi)
    {
      int mid = lo + (hi - lo) / 2;
      int num = nums[mid];
      if (num == target)
      {
        int loNum = nums[lo];
        int hiNum = nums[hi];
        if (loNum == target && hiNum == target) break;
        if (loNum != target) lo++;
        if (hiNum != target) hi--;
      }
      else if (num < target) lo = mid + 1;
      else hi = mid - 1;
    }
    if (nums[lo] != target || nums[hi] != target)
    {
      lo = -1;
      hi = -1;
    }
    return new int[] { lo, hi };
  }

  public int[] SearchRange(int[] nums, int target)
  {
    int start = -1, end = -1;
    if (nums.Length > 0)
    {
      // binary search the range
      return Search(nums, target, 0, nums.Length - 1);
    }
    return new int[] { start, end };
  }
}
