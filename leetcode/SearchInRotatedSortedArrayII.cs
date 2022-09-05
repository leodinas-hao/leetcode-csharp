/*
Search in Rotated Sorted Array II
https://leetcode.com/problems/search-in-rotated-sorted-array-ii/

There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).
Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) 
such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].

Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.
You must decrease the overall operation steps as much as possible.

Example 1:
Input: nums = [2,5,6,0,0,1,2], target = 0
Output: true

Example 2:
Input: nums = [2,5,6,0,0,1,2], target = 3
Output: false

Constraints:
1 <= nums.length <= 5000
-10^4 <= nums[i] <= 10^4
nums is guaranteed to be rotated at some pivot.
-10^4 <= target <= 10^4

Follow up: This problem is similar to Search in Rotated Sorted Array, but nums may contain duplicates. 
           Would this affect the runtime complexity? How and why?
*/

namespace LeetCode.SearchInRotatedSortedArrayII;

public class Solution
{
  // returns true if we can reduce the search space in current binary search space
  private bool IsBinarySearchHelpful(int[] arr, int start, int element)
  {
    return arr[start] != element;
  }

  // returns true if element exists in first array, false if it exists in second
  private bool ExistsInFirst(int[] arr, int start, int element)
  {
    return arr[start] <= element;
  }

  public bool Search(int[] nums, int target)
  {
    int n = nums.Length;
    if (n == 0) return false;
    int end = n - 1, start = 0;

    while (start <= end)
    {
      int mid = (start + end) / 2;
      if (nums[mid] == target) return true;

      if (!IsBinarySearchHelpful(nums, start, nums[mid]))
      {
        start++;
        continue;
      }

      bool pivotArray = ExistsInFirst(nums, start, nums[mid]);

      bool targetArray = ExistsInFirst(nums, start, target);

      if (pivotArray ^ targetArray)
      {
        // if pivot and target exist in different sorted arrays, 
        // recall that xor is true when both operands are distinct

        // pivot in the first, target in the second
        if (pivotArray) start = mid + 1;
        // target in the first, pivot in the second
        else end = mid - 1;
      }
      else
      {
        // if pivot and target exist in same sorted array
        if (nums[mid] < target) start = mid + 1;
        else end = mid - 1;
      }

    }
    return false;
  }
}