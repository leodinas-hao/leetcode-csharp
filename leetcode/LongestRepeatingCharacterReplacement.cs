/*
Longest Repeating Character Replacement
https://leetcode.com/problems/longest-repeating-character-replacement/

You are given a string s and an integer k. You can choose any character of the string and change it to any other uppercase English character. 
You can perform this operation at most k times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.

Example 1:
Input: s = "ABAB", k = 2
Output: 4
Explanation: Replace the two 'A's with two 'B's or vice versa.

Example 2:
Input: s = "AABABBA", k = 1
Output: 4
Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.

Constraints:
1 <= s.length <= 10^5
s consists of only uppercase English letters.
0 <= k <= s.length
*/

namespace LeetCode.LongestRepeatingCharacterReplacement;

public class Solution
{
  public int CharacterReplacement(string s, int k)
  {
    int ans = 0, start = 0, maxCount = 0;
    var map = new Dictionary<char, int>();
    for (int end = 0; end < s.Length; end++)
    {
      char c = s[end];
      map[c] = 1 + (map.ContainsKey(c) ? map[c] : 0);
      maxCount = Math.Max(maxCount, map[c]);

      while (end - start + 1 - maxCount > k)
      {
        map[s[start]]--;
        start++;
      }

      ans = Math.Max(ans, end - start + 1);
    }
    return ans;
  }
}