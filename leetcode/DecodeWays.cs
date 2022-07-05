/*
Decode Ways
https://leetcode.com/problems/decode-ways/

A message containing letters from A-Z can be encoded into numbers using the following mapping:

'A' -> "1"
'B' -> "2"
...
'Z' -> "26"

To decode an encoded message, all the digits must be grouped then mapped back into letters 
using the reverse of the mapping above (there may be multiple ways). For example, "11106" can be mapped into:
- "AAJF" with the grouping (1 1 10 6)
- "KJF" with the grouping (11 10 6)

Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".
Given a string s containing only digits, return the number of ways to decode it.
The test cases are generated so that the answer fits in a 32-bit integer.

Example 1:
Input: s = "12"
Output: 2
Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).

Example 2:
Input: s = "226"
Output: 3
Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

Example 3:
Input: s = "06"
Output: 0
Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").

Constraints:
1 <= s.length <= 100
s contains only digits and may contain leading zero(s).
*/

namespace LeetCode.DecodeWays;

public class Solution
{
  public int NumDecodings(string s)
  {
    // leading 0 can't make a valid code
    if (s.StartsWith("0")) return 0;

    // dp[i] indicates number of valid codes between s[0..(i+1)]
    int[] dp = new int[s.Length];
    dp[0] = 1;

    for (int i = 1; i < s.Length; i++)
    {
      // current digit is not 0
      if (s[i] != '0') dp[i] = dp[i - 1];

      // check if 2 digit combination possible
      // 10 ~ 26
      int twoDigits = Int32.Parse($"{s[i - 1]}{s[i]}");
      if (twoDigits >= 10 && twoDigits <= 26)
      {
        dp[i] += i < 2 ? dp[i - 1] : dp[i - 2];
      }
    }
    return dp[^1];
  }
}
