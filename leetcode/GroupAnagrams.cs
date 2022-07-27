/*
Group Anagrams
https://leetcode.com/problems/group-anagrams/

Given an array of strings strs, group the anagrams together. You can return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Example 2:
Input: strs = [""]
Output: [[""]]

Example 3:
Input: strs = ["a"]
Output: [["a"]]

Constraints:
1 <= strs.length <= 10^4
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
*/

namespace LeetCode.GroupAnagrams;

public class Solution
{
  public IList<IList<string>> GroupAnagrams(string[] strs)
  {
    var ans = new List<IList<string>>();

    if (strs.Length == 0) return ans;

    Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();

    foreach (var s in strs)
    {
      char[] hash = new char[26];

      foreach (char c in s.ToCharArray())
      {
        hash[c - 'a']++;
      }

      string key = new String(hash);
      if (!map.ContainsKey(key)) map.Add(key, new List<string>());
      map[key].Add(s);
    }
    ans.AddRange(map.Values);
    return ans;
  }
}
