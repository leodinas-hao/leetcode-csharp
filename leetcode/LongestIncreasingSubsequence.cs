/*
Longest Increasing Subsequence
https://leetcode.com/problems/longest-increasing-subsequence/

Given an integer array nums, return the length of the longest strictly increasing subsequence.

A subsequence is a sequence that can be derived from an array by deleting some or 
no elements without changing the order of the remaining elements. For example, [3,6,2,7] is a subsequence of the array [0,3,1,6,2,2,7].

Example 1:
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

Example 2:
Input: nums = [0,1,0,3,2,3]
Output: 4

Example 3:
Input: nums = [7,7,7,7,7,7,7]
Output: 1

Constraints:
1 <= nums.length <= 2500
-10^4 <= nums[i] <= 10^4
*/

namespace LeetCode.LongestIncreasingSubsequence;

/*
DP
*/
public class Solution
{
  public int LengthOfLIS(int[] nums)
  {
    int len = nums.Length;
    // an array stores the longest increasing subsequence from the index to the last index
    var dp = new int[len];
    Array.Fill(dp, 1);

    // index of left end of the subsequence, starting from the last index
    for (int i = len - 1; i >= 0; i--)
    {
      // index of right end of the subsequence, starting from "left index + 1"
      for (int j = i + 1; j < len; j++)
      {
        if (nums[i] < nums[j]) dp[i] = Math.Max(dp[i], 1 + dp[j]);
      }
    }

    return dp.Max();
  }
}
