/*
Minimum Size Subarray Sum
https://leetcode.com/problems/minimum-size-subarray-sum/

Given an array of positive integers nums and a positive integer target, 
return the minimal length of a contiguous subarray [numsl, numsl+1, ..., numsr-1, numsr] 
of which the sum is greater than or equal to target. 
If there is no such subarray, return 0 instead.

Example 1:
Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.

Example 2:
Input: target = 4, nums = [1,4,4]
Output: 1

Example 3:
Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0

Constraints:
1 <= target <= 10^9
1 <= nums.length <= 10^5
1 <= nums[i] <= 10^4

Follow up: If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log(n)).
*/

namespace LeetCode.MinimumSizeSubarraySum;

public class Solution
{
  public int MinSubArrayLen(int target, int[] nums)
  {
    int left = 0, right = 0, sum = 0, min = int.MaxValue;
    while (right < nums.Length)
    {
      sum += nums[right];
      while (sum >= target)
      {
        min = Math.Min(min, right - left + 1);
        sum -= nums[left++];
      }
      right++;
    }
    return min == int.MaxValue ? 0 : min;
  }
}
