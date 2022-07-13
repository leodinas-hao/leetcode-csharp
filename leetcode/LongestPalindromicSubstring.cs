/*
Longest Palindromic Substring
https://leetcode.com/problems/longest-palindromic-substring/

Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"

Constraints:
1 <= s.length <= 1000
s consist of only digits and English letters.
*/

namespace LeetCode.LongestPalindromicSubstring;

public class Solution
{
  public string LongestPalindrome(string s)
  {
    // given constraints s.length >=1
    int len = s.Length;
    string ans = "";
    int max = 0;

    bool[,] dp = new bool[len, len];
    for (int r = 0; r < len; r++)
    {
      for (int l = 0; l <= r; l++)
      {
        bool judge = s[r] == s[l];
        dp[l, r] = r - l > 2 ? dp[l + 1, r - 1] && judge : judge;

        if (dp[l, r] && r - l + 1 > max)
        {
          max = r - l + 1;
          ans = s.Substring(l, max);
        }
      }
    }
    return ans;
  }
}