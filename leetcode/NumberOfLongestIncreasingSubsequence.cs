/*
Number of Longest Increasing Subsequence
https://leetcode.com/problems/number-of-longest-increasing-subsequence/

Given an integer array nums, return the number of longest increasing subsequences.
Notice that the sequence has to be strictly increasing.

Example 1:
Input: nums = [1,3,5,4,7]
Output: 2
Explanation: The two longest increasing subsequences are [1, 3, 4, 7] and [1, 3, 5, 7].

Example 2:
Input: nums = [2,2,2,2,2]
Output: 5
Explanation: The length of the longest increasing subsequence is 1, and there are 5 increasing subsequences of length 1, so output 5.

Constraints:
1 <= nums.length <= 2000
-10^6 <= nums[i] <= 10^6
*/

namespace LeetCode.NumberOfLongestIncreasingSubsequence;

public class Solution
{
  public int FindNumberOfLIS(int[] nums)
  {
    int n = nums.Length;
    // the max len of increasing sequence ending at i
    var dp = new int[n];
    Array.Fill(dp, 1);
    // the counts of increasing sequences 
    var counts = new int[n];
    Array.Fill(counts, 1);

    int max = 0, count = 0;

    for (int r = 0; r < n; r++)
    {
      for (int l = 0; l < r; l++)
      {
        if (nums[l] < nums[r])
        {
          if (dp[l] + 1 > dp[r])
          {
            dp[r] = dp[l] + 1;
            counts[r] = counts[l];
          }
          else if (dp[l] + 1 == dp[r])
          {
            counts[r] += counts[l];
          }
        }
      }

      if (dp[r] == max) count += counts[r];
      else if (dp[r] > max)
      {
        max = dp[r];
        count = counts[r];
      }
    }

    return count;
  }
}