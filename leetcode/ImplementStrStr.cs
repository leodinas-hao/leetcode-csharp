/*
Implement strStr()
https://leetcode.com/problems/implement-strstr/

Implement strStr().
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
Clarification:
What should we return when needle is an empty string? This is a great question to ask during an interview.
For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

Example 1:
Input: haystack = "hello", needle = "ll"
Output: 2

Example 2:
Input: haystack = "aaaaa", needle = "bba"
Output: -1

Constraints:
1 <= haystack.length, needle.length <= 10^4
haystack and needle consist of only lowercase English characters.
*/

namespace LeetCode.ImplementStrStr;

public class Solution
{
  public int StrStr(string haystack, string needle)
  {
    if (needle.Length == 0 || needle == haystack) return 0;
    if (needle.Length > haystack.Length) return -1;

    for (int i = 0; i < haystack.Length; i++)
    {
      if (haystack[i] == needle[0] && i + needle.Length <= haystack.Length)
      {
        for (int j = 0; j < needle.Length; j++)
        {
          if (needle[j] != haystack[i + j]) break;
          if (j == needle.Length - 1) return i;
        }
      }
    }

    return -1;
  }
}