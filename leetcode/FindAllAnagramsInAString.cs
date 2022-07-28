/*
Find All Anagrams in a String
https://leetcode.com/problems/find-all-anagrams-in-a-string/

Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".

Example 2:
Input: s = "abab", p = "ab"
Output: [0,1,2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".

Constraints:
1 <= s.length, p.length <= 3 * 10^4
s and p consist of lowercase English letters.
*/

namespace LeetCode.FindAllAnagramsInAString;

public class Solution
{
  public IList<int> FindAnagrams(string s, string p)
  {
    int[] pmap = new int[26];
    int[] window = new int[26];
    List<int> result = new List<int>();
    int sLen = s.Length, pLen = p.Length;
    // no need to check when p is longer than s
    if (sLen < pLen) return result;

    // first window
    for (int i = 0; i < pLen; i++)
    {
      pmap[p[i] - 'a']++;
      window[s[i] - 'a']++;
    }

    if (Enumerable.SequenceEqual(pmap, window)) result.Add(0);

    // remaining windows
    for (int i = pLen; i < sLen; i++)
    {
      window[s[i - pLen] - 'a']--;
      window[s[i] - 'a']++;
      if (Enumerable.SequenceEqual(pmap, window)) result.Add(i - pLen + 1);
    }

    return result;
  }
}