/*
Longest Substring Without Repeating Characters
https://leetcode.com/problems/longest-substring-without-repeating-characters/

Given a string s, find the length of the longest substring without repeating characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Constraints:
0 <= s.length <= 5 * 10^4
s consists of English letters, digits, symbols and spaces.
*/

namespace LeetCode.LongestSubstringWithoutRepeatingCharacters;

public class Solution
{
  public int LengthOfLongestSubstring(string s)
  {
    if (s.Length <= 1) return s.Length;
    int max = 0, found = -1;
    string sub = "";
    for (int i = 0; i < s.Length; i++)
    {
      found = sub.IndexOf(s[i]);
      if (found > -1)
      {
        // found matching
        // update substring: 
        // 1). removing all chars prior the matching char
        // 2). append the new char to the end
        sub = sub.Remove(0, found + 1) + s[i].ToString();
      }
      else
      {
        sub = sub + s[i].ToString();
      }
      max = Math.Max(max, sub.Length);
    }
    return max;
  }
}
