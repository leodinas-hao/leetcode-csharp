/*
Arithmetic Slices
https://leetcode.com/problems/arithmetic-slices/

An integer array is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.
For example, [1,3,5,7,9], [7,7,7,7], and [3,-1,-5,-9] are arithmetic sequences.
Given an integer array nums, return the number of arithmetic subarrays of nums.

A subarray is a contiguous subsequence of the array.

Example 1:
Input: nums = [1,2,3,4]
Output: 3
Explanation: We have 3 arithmetic slices in nums: [1, 2, 3], [2, 3, 4] and [1,2,3,4] itself.

Example 2:
Input: nums = [1]
Output: 0

Constraints:
1 <= nums.length <= 5000
-1000 <= nums[i] <= 1000
*/

namespace LeetCode.ArithmeticSlices;

public class Solution
{
  public int NumberOfArithmeticSlices(int[] nums)
  {
    if (nums.Length < 3) return 0;

    // dp[i] represents how many arithmetic sequence in range [0,i]
    int[] dp = new int[nums.Length];
    int ans = 0;

    // dp[i] = dp[i-1] + 1 then total number of arithmetic slices += dp[i]
    // consider
    // [1,2,3]      |  [1,2,3]                          | +1
    // [1,2,3,4]    |  [2,3,4], [1,2,3,4]               | +2
    // [1,2,3,4,5]  |  [3,4,5], [2,3,4,5], [1,2,3,4,5]  | +3
    for (int i = 2; i < nums.Length; i++)
    {
      if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
        dp[i] = dp[i - 1] + 1;

      ans += dp[i];
    }
    return ans;
  }
}
