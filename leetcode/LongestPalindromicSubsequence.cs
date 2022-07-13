/*
Longest Palindromic Subsequence
https://leetcode.com/problems/longest-palindromic-subsequence/

Given a string s, find the longest palindromic subsequence's length in s.
A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.

Example 1:
Input: s = "bbbab"
Output: 4
Explanation: One possible longest palindromic subsequence is "bbbb".

Example 2:
Input: s = "cbbd"
Output: 2
Explanation: One possible longest palindromic subsequence is "bb".

Constraints:
1 <= s.length <= 1000
s consists only of lowercase English letters.
*/

namespace LeetCode.LongestPalindromicSubsequence;

public class Solution
{
  public int LongestPalindromeSubseq(string s)
  {
    int n = s.Length;

    var dp = new int[n, n];

    // substrings of length 1 are palindromic subsequence length 1
    for (int i = 0; i < n; i++)
    {
      dp[i, i] = 1;
    }

    // iterate substrings with minimum length of 2 and above
    for (int len = 2; len <= n; len++)
    {
      for (int l = 0; l < n - len + 1; l++)
      {
        int r = l + len - 1;
        if (s[r] == s[l])
        {
          if (len == 2) dp[l, r] = 2;
          else dp[l, r] = 2 + dp[l + 1, r - 1];
        }
        else
        {
          dp[l, r] = Math.Max(dp[l + 1, r], dp[l, r - 1]);
        }
      }
    }

    return dp[0, n - 1];
  }
}