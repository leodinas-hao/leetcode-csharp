/*
Plus one
https://leetcode.com/problems/plus-one/

You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer.
The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.

Increment the large integer by one and return the resulting array of digits.

Example 1:
Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Incrementing by one gives 123 + 1 = 124.
Thus, the result should be [1,2,4].

Example 2:
Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
Incrementing by one gives 4321 + 1 = 4322.
Thus, the result should be [4,3,2,2].

Example 3:
Input: digits = [9]
Output: [1,0]
Explanation: The array represents the integer 9.
Incrementing by one gives 9 + 1 = 10.
Thus, the result should be [1,0].

Constraints:
1 <= digits.length <= 100
0 <= digits[i] <= 9
digits does not contain any leading 0's.
*/

namespace LeetCode.PlusOne;

public class Solution
{
  public int[] PlusOne(int[] digits)
  {
    IEnumerable<int> ls = new List<int>();
    int carryover = 0;

    for (int i = digits.Length - 1; i >= 0; i--)
    {
      int sum = digits[i] + (i < digits.Length - 1 ? carryover : 1);
      if (sum >= 10)
      {
        carryover = 1;
        sum = sum % 10;
      }
      else
      {
        carryover = 0;
      }
      // "prepend" doesn't modify the existing list, instead it returns a modified copy of the list
      ls = ls.Prepend(sum);
    }

    if (carryover > 0) ls = ls.Prepend(carryover);

    return ls.ToArray();
  }
}