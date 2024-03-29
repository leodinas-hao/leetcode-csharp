/*
Largest Substring Between Two Equal Characters
https://leetcode.com/problems/largest-substring-between-two-equal-characters/

Given a string s, return the length of the longest substring between two equal characters, excluding the two characters. If there is no such substring return -1.
A substring is a contiguous sequence of characters within a string.



Example 1:
Input: s = "aa"
Output: 0
Explanation: The optimal substring here is an empty substring between the two 'a's.

Example 2:
Input: s = "abca"
Output: 2
Explanation: The optimal substring here is "bc".

Example 3:
Input: s = "cbzxy"
Output: -1
Explanation: There are no characters that appear twice in s.

Constraints:
1 <= s.length <= 300
s contains only lowercase English letters.
*/

namespace LeetCode.LargestSubstringBetweenTwoEqualCharacters;

public class Solution
{
  public int MaxLengthBetweenEqualCharacters(string s)
  {
    int ans = -1;
    Dictionary<char, int> firstIndex = new Dictionary<char, int>();
    for (int i = 0; i < s.Length; i++)
    {
      if (firstIndex.ContainsKey(s[i])) ans = Math.Max(ans, i - firstIndex[s[i]] - 1);
      else firstIndex[s[i]] = i;
    }
    return ans;
  }
}
