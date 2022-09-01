/*
Single Element in a Sorted Array
https://leetcode.com/problems/single-element-in-a-sorted-array

You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once.
Return the single element that appears only once.
Your solution must run in O(log n) time and O(1) space.

Example 1:
Input: nums = [1,1,2,3,3,4,4,8,8]
Output: 2

Example 2:
Input: nums = [3,3,7,7,10,11,11]
Output: 10

Constraints:
1 <= nums.length <= 10^5
0 <= nums[i] <= 10^5
*/

namespace LeetCode.SingleElementInASortedArray;

public class Solution
{
  public int SingleNonDuplicate(int[] nums)
  {
    int lo = 0, hi = nums.Length - 2;
    while (lo <= hi)
    {
      int mid = (lo + hi) / 2;
      if (nums[mid] == nums[mid ^ 1]) lo = mid + 1;
      else hi = mid - 1;
    }
    return nums[lo];
  }
}

public class Solution2
{
  private int Search(int[] nums, int start, int end)
  {
    int mid = (start + end) / 2;
    if (mid % 2 == 1) mid--;
    if (mid - 1 >= 0 && nums[mid] == nums[mid - 1]) return Search(nums, start, mid - 2);
    else if (mid < nums.Length - 2 && nums[mid] == nums[mid + 1]) return Search(nums, mid + 2, end);
    else return mid;
  }

  public int SingleNonDuplicate(int[] nums)
  {
    return nums[Search(nums, 0, nums.Length - 1)];
  }
}
