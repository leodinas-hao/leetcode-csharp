/*
Letter Combinations of a Phone Number
https://leetcode.com/problems/letter-combinations-of-a-phone-number/

Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
Return the answer in any order.
A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:
Input: digits = ""
Output: []

Example 3:
Input: digits = "2"
Output: ["a","b","c"]

Constraints:
0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
*/

namespace LeetCode.LetterCombinationsOfAPhoneNumber;

public class Solution
{
  private Dictionary<char, char[]> map = new Dictionary<char, char[]>
  {
    {'2', new char[]{'a','b','c'}},
    {'3', new char[]{'d','e','f'}},
    {'4', new char[]{'g','h','i'}},
    {'5', new char[]{'j','k','l'}},
    {'6', new char[]{'m','n','o'}},
    {'7', new char[]{'p','q','r','s'}},
    {'8', new char[]{'t','u','v'}},
    {'9', new char[]{'w','x','y','z'}},
  };

  private void Helper(string digits, int index, string comb, IList<string> output)
  {
    if (index == digits.Length)
    {
      output.Add(comb);
      return;
    }

    char[] chars = map[digits[index]];

    for (int i = 0; i < chars.Length; i++)
    {
      Helper(digits, index + 1, comb + chars[i], output);
    }
  }

  public IList<string> LetterCombinations(string digits)
  {
    var output = new List<string>();
    if (digits.Length == 0) return output;

    Helper(digits, 0, "", output);

    return output;
  }
}