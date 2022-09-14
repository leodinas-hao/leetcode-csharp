/*
Isomorphic Strings
https://leetcode.com/problems/isomorphic-strings/

Given two strings s and t, determine if they are isomorphic.
Two strings s and t are isomorphic if the characters in s can be replaced to get t.
All occurrences of a character must be replaced with another character while preserving the order of characters. 
No two characters may map to the same character, but a character may map to itself.

Example 1:
Input: s = "egg", t = "add"
Output: true

Example 2:
Input: s = "foo", t = "bar"
Output: false

Example 3:
Input: s = "paper", t = "title"
Output: true

Constraints:
1 <= s.length <= 5 * 10^4
t.length == s.length
s and t consist of any valid ascii character.
*/

namespace LeetCode.IsomorphicStrings;

/*
if two strings are isomorphic, then both have the same patten of char index occurrences
meaning if replacing the char with the first time occurrence(index) of the string, both strings should be the same
e.g.
paper ==> 01034
title ==> 01034
*/
public class Solution
{
  public string Transform(string str)
  {
    var map = new Dictionary<char, int>();
    string transformed = "";
    for (int i = 0; i < str.Length; i++)
    {
      if (!map.ContainsKey(str[i])) map.Add(str[i], i);
      transformed += $"{map[str[i]]} ";
    }
    return transformed;
  }

  public bool IsIsomorphic(string s, string t)
  {
    return Transform(s) == Transform(t);
  }
}
