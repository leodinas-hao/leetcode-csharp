/*
Find Smallest Letter Greater Than Target
https://leetcode.com/problems/find-smallest-letter-greater-than-target/

Given a characters array letters that is sorted in non-decreasing order and a character target, 
return the smallest character in the array that is larger than target.

Note that the letters wrap around.

For example, if target == 'z' and letters == ['a', 'b'], the answer is 'a'.

Example 1:
Input: letters = ["c","f","j"], target = "a"
Output: "c"

Example 2:
Input: letters = ["c","f","j"], target = "c"
Output: "f"

Example 3:
Input: letters = ["c","f","j"], target = "d"
Output: "f"

Constraints:
2 <= letters.length <= 104
letters[i] is a lowercase English letter.
letters is sorted in non-decreasing order.
letters contains at least two different characters.
target is a lowercase English letter.
*/

namespace LeetCode.FindSmallestLetterGreaterThanTarget;

public class Solution
{
  public char NextGreatestLetter(char[] letters, char target)
  {
    char result = letters[0];
    int left = 0, right = letters.Length - 1;
    while (left <= right)
    {
      int mid = left + (right - left) / 2;
      if (letters[mid] > target)
      {
        result = letters[mid];
        right = mid - 1;
      }
      else
      {
        left = mid + 1;
      }
    }
    return result;
  }
}
