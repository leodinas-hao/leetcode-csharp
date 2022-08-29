/*
Find the Duplicate Number
https://leetcode.com/problems/find-the-duplicate-number/

Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.
There is only one repeated number in nums, return this repeated number.
You must solve the problem without modifying the array nums and uses only constant extra space.

Example 1:
Input: nums = [1,3,4,2,2]
Output: 2

Example 2:
Input: nums = [3,1,3,4,2]
Output: 3

Constraints:
1 <= n <= 10^5
nums.length == n + 1
1 <= nums[i] <= n
All the integers in nums appear only once except for precisely one integer which appears two or more times.
*/

namespace LeetCode.FindTheDuplicateNumber;

/*
binary search to find the smallest number `n`, which has the count (number in array and <= `n`) greater than `n`

consider a range [1, 5], when no duplicate, if count the number less than or equal to the number itself
(1,2,3,4,5) => (1,2,3,4,5) e.g. 3 has 3 numbers less than or equal to itself
when there is duplicate, consider [1,3,4,2,2] => (1,2,3,4) => (1,3,4,5) then the duplicate is 2
*/
public class Solution
{
  public int FindDuplicate(int[] nums)
  {
    // as array is indexed starting from 1
    // the highest number in the array should be nums.Length - 1
    int lo = 1, hi = nums.Length - 1;
    int duplicate = -1;

    while (lo <= hi)
    {
      int mid = (lo + hi) / 2;
      int count = 0;
      foreach (int n in nums)
      {
        if (n <= mid) count++;
        if (count > mid) break;
      }
      if (count > mid)
      {
        duplicate = mid;
        hi = mid - 1;
      }
      else lo = mid + 1;
    }

    return duplicate;
  }
}