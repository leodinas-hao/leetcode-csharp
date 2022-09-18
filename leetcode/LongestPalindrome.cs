/*
Longest Palindrome
https://leetcode.com/problems/longest-palindrome/

Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.
Letters are case sensitive, for example, "Aa" is not considered a palindrome here.

Example 1:
Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.

Example 2:
Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.

Constraints:
1 <= s.length <= 2000
s consists of lowercase and/or uppercase English letters only.
*/

namespace LeetCode.LongestPalindrome;

public class Solution
{
  public int LongestPalindrome(string s)
  {
    int pairs = 0;
    HashSet<char> unpaired = new HashSet<char>();

    foreach (var c in s)
    {
      if (unpaired.Contains(c))
      {
        pairs++;
        unpaired.Remove(c);
      }
      else unpaired.Add(c);
    }

    return pairs * 2 + (unpaired.Any() ? 1 : 0);
  }
}
