/*
Permutation in String
https://leetcode.com/problems/permutation-in-string/

Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
In other words, return true if one of s1's permutations is the substring of s2.

Example 1:
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").

Example 2:
Input: s1 = "ab", s2 = "eidboaoo"
Output: false

Constraints:
1 <= s1.length, s2.length <= 10^4
s1 and s2 consist of lowercase English letters.
*/

namespace LeetCode.PermutationInString;

public class Solution
{
  private bool Match(int[] s1, int[] s2)
  {
    // check the 2 letter arrays to see if the letter occurrences are the same
    for (int i = 0; i < 26; i++)
    {
      if (s1[i] != s2[i]) return false;
    }
    return true;
  }

  public bool CheckInclusion(string s1, string s2)
  {
    if (s1.Length > s2.Length) return false;

    // as there are only 26 lowercase letters
    // put the number of occurrences of each letter in s1/s2 into an array
    int[] s1map = new int[26];
    int[] s2map = new int[26];
    for (int i = 0; i < s1.Length; i++)
    {
      s1map[s1[i] - 'a']++;
      s2map[s2[i] - 'a']++;
    }

    for (int i = 0; i < s2.Length - s1.Length; i++)
    {
      if (Match(s1map, s2map)) return true;
      // add next char to s2map
      s2map[s2[i + s1.Length] - 'a']++;
      // remove the current char from s2map
      s2map[s2[i] - 'a']--;
    }
    return Match(s1map, s2map);
  }
}
