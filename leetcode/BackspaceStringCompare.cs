/*
Backspace String Compare
https://leetcode.com/problems/backspace-string-compare/

Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

Note that after backspacing an empty text, the text will continue empty.

Example 1:
Input: s = "ab#c", t = "ad#c"
Output: true
Explanation: Both s and t become "ac".

Example 2:
Input: s = "ab##", t = "c#d#"
Output: true
Explanation: Both s and t become "".

Example 3:
Input: s = "a#c", t = "b"
Output: false
Explanation: s becomes "c" while t becomes "b".

Constraints:
1 <= s.length, t.length <= 200
s and t only contain lowercase letters and '#' characters.
*/

namespace LeetCode.BackspaceStringCompare;

public class Solution
{
  public bool BackspaceCompare(string s, string t)
  {
    int i = s.Length - 1, j = t.Length - 1;
    // track number of backspaces to read the next character
    int skipS = 0, skipT = 0;
    while (i >= 0 || j >= 0)
    {
      // find next char position (not backspace)
      while (i >= 0)
      {
        if (s[i] == '#') { skipS++; i--; }
        else if (skipS > 0) { skipS--; i--; }
        else break; // char position
      }

      while (j >= 0)
      {
        if (t[j] == '#') { skipT++; j--; }
        else if (skipT > 0) { skipT--; j--; }
        else break; // char position
      }

      // compare the chars
      if (i >= 0 && j >= 0 && s[i] != t[j]) return false;
      // if one string still has chars, but not the other
      if ((i >= 0) != (j >= 0)) return false;
      i--;
      j--;
    }
    return true;
  }
}
