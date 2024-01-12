/*
Determine if String Halves Are Alike
https://leetcode.com/problems/determine-if-string-halves-are-alike/

You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.

Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). 
Notice that s contains uppercase and lowercase letters.

Return true if a and b are alike. Otherwise, return false.
 

Example 1:
Input: s = "book"
Output: true
Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.

Example 2:
Input: s = "textbook"
Output: false
Explanation: a = "text" and b = "book". a has 1 vowel whereas b has 2. Therefore, they are not alike.
Notice that the vowel o is counted twice.

Constraints:
2 <= s.length <= 1000
s.length is even.
s consists of uppercase and lowercase letters.
*/

namespace LeetCode.DetermineIfStringHalvesAreAlike;

public class Solution
{
  public bool HalvesAreAlike(string s)
  {
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    int left = 0, right = s.Length - 1;
    int a = 0, b = 0;  // count number of vowels in a and b
    while (left < right)
    {
      if (vowels.Contains(s[left])) a++;
      if (vowels.Contains(s[right])) b++;
      left++;
      right--;
    }
    return a == b;
  }
}
