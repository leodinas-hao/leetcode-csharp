/*
Reverse Vowels of a String
https://leetcode.com/problems/reverse-vowels-of-a-string/description/

Given a string s, reverse only all the vowels in the string and return it.

The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

Example 1:
Input: s = "hello"
Output: "holle"

Example 2:
Input: s = "leetcode"
Output: "leotcede"

Constraints:
1 <= s.length <= 3 * 10^5
s consist of printable ASCII characters.
*/

namespace LeetCode.ReverseVowelsOfAString;

public class Solution
{
  private char[] vowels = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

  private bool IsVowel(char c)
  {
    return vowels.Contains(c);
  }

  private void Swap(char[] chars, int x, int y)
  {
    char temp = chars[x];
    chars[x] = chars[y];
    chars[y] = temp;
  }

  public string ReverseVowels(string s)
  {
    int start = 0, end = s.Length - 1;
    var chars = s.ToCharArray();
    while (start < end)
    {
      while (start < s.Length && !IsVowel(chars[start]))
        start++;

      while (end >= 0 && !IsVowel(chars[end]))
        end--;

      if (start < end)
        Swap(chars, start++, end--);
    }
    return new String(chars);
  }
}