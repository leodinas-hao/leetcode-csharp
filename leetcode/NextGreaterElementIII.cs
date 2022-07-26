/*
Next Greater Element III
https://leetcode.com/problems/next-greater-element-iii/

Given a positive integer n, find the smallest integer which has exactly the same digits existing in the integer n 
and is greater in value than n. If no such positive integer exists, return -1.
Note that the returned integer should fit in 32-bit integer, if there is a valid answer but it does not fit in 32-bit integer, return -1.

Example 1:
Input: n = 12
Output: 21

Example 2:
Input: n = 21
Output: -1

Constraints:
1 <= n <= 2^31 - 1
*/

namespace LeetCode.NextGreaterElementIII;

public class Solution
{
  public int NextGreaterElement(int n)
  {
    // consider example: 230241
    // get all digits from n
    int[] digits = n.ToString().Select(c => Int32.Parse(c.ToString())).ToArray();

    // find the index of the first digit (from right) that is smaller than the previous digit
    // find 230(2)41
    int index = -1;
    for (int i = digits.Length - 2; i >= 0; i--)
    {
      if (digits[i] < digits[i + 1])
      {
        index = i;
        break;
      }
    }
    // if no such digit exists, return -1
    if (index == -1)
    {
      return -1;
    }
    // find the index of the first digit that is greater than the digit at index
    // find 230(2)(4)1
    int nextIndex = -1;
    for (int i = digits.Length - 1; i > index; i--)
    {
      if (digits[i] > digits[index])
      {
        nextIndex = i;
        break;
      }
    }
    // swap the digits at index and nextIndex
    // swap to make 230(4)(2)1
    int temp = digits[index];
    digits[index] = digits[nextIndex];
    digits[nextIndex] = temp;

    // reverse the digits from index + 1 to the end
    // reserve to make 230(4)(1)(2)
    Array.Reverse(digits, index + 1, digits.Length - index - 1);

    // combine the digits and convert to int
    int result = 0;
    for (int i = 0; i < digits.Length; i++)
    {
      // if result is greater than Int32.MaxValue, return -1
      if (result > (Int32.MaxValue - digits[i]) / 10) return -1;
      result = result * 10 + digits[i];
    }

    return result;

  }
}
