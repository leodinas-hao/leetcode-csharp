/*
Repeated Substring Pattern
https://leetcode.com/problems/repeated-substring-pattern/

Given a string s, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.

Example 1:
Input: s = "abab"
Output: true
Explanation: It is the substring "ab" twice.

Example 2:
Input: s = "aba"
Output: false

Example 3:
Input: s = "abcabcabcabc"
Output: true
Explanation: It is the substring "abc" four times or the substring "abcabc" twice.

Constraints:
1 <= s.length <= 10^4
s consists of lowercase English letters.
*/

namespace LeetCode.RepeatedSubstringPattern;

/*
consider if `s = "aa"`, then double the s to make `ss = "aaaa"`
then if `s` is repeated string, then `ss[1..^1]` should contains `s`
*/
public class Solution
{
  public bool RepeatedSubstringPattern(string s)
  {
    string ss = s + s;
    ss = ss.Substring(1, ss.Length - 2);
    return ss.Contains(s);
  }
}


/*
time limit exceeded on LeetCode
*/
public class Solution2
{
  public bool RepeatedSubstringPattern(string s)
  {
    for (int i = 0; i < s.Length / 2; i++)
    {
      string sub = s.Substring(0, i + 1);
      if (s.Length % (i + 1) == 0)
      {
        int repeat = s.Length / (i + 1);
        if (RepeatStr(sub, repeat) == s) return true;
      }
    }
    return false;
  }

  private string RepeatStr(string str, int repeat)
  {
    string repeatedStr = "";
    for (int i = 0; i < repeat; i++)
    {
      repeatedStr += str;
    }
    return repeatedStr;
  }
}