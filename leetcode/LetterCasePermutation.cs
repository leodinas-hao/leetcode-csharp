/*
Letter Case Permutation
https://leetcode.com/problems/letter-case-permutation/

Given a string s, you can transform every letter individually to be lowercase or uppercase to create another string.
Return a list of all possible strings we could create. Return the output in any order.

Example 1:
Input: s = "a1b2"
Output: ["a1b2","a1B2","A1b2","A1B2"]

Example 2:
Input: s = "3z4"
Output: ["3z4","3Z4"]

Constraints:
1 <= s.length <= 12
s consists of lowercase English letters, uppercase English letters, and digits.
*/

namespace LeetCode.LetterCasePermutation;

public class Solution
{
  private void ChangeCase(string s, string output, IList<string> all)
  {
    if (s.Length == 0)
    {
      all.Add(output);
      return;
    }

    if (Char.IsNumber(s[0]))
    {
      // just append the number to output
      // and remove the processed letter and move to next
      ChangeCase(s.Substring(1), output + s[0], all);
    }
    else
    {
      // English letters
      // no change case
      ChangeCase(s.Substring(1), output + s[0], all);
      // change case
      ChangeCase(s.Substring(1), output + (Char.IsLower(s[0]) ? Char.ToUpper(s[0]) : Char.ToLower(s[0])), all);
    }
  }

  public IList<string> LetterCasePermutation(string s)
  {
    var permutations = new List<string>();
    ChangeCase(s, "", permutations);
    return permutations;
  }
}