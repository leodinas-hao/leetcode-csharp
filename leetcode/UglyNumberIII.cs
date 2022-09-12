/*
Ugly Number III
https://leetcode.com/problems/ugly-number-iii/

An ugly number is a positive integer that is divisible by a, b, or c.

Given four integers n, a, b, and c, return the nth ugly number.

Example 1:
Input: n = 3, a = 2, b = 3, c = 5
Output: 4
Explanation: The ugly numbers are 2, 3, 4, 5, 6, 8, 9, 10... The 3rd is 4.

Example 2:
Input: n = 4, a = 2, b = 3, c = 4
Output: 6
Explanation: The ugly numbers are 2, 3, 4, 6, 8, 9, 10, 12... The 4th is 6.

Example 3:
Input: n = 5, a = 2, b = 11, c = 13
Output: 10
Explanation: The ugly numbers are 2, 4, 6, 8, 10, 11, 12, 13... The 5th is 10.

Constraints:
1 <= n, a, b, c <= 10^9
1 <= a * b * c <= 10^18
It is guaranteed that the result will be in range [1, 2 * 10^9].
*/

namespace LeetCode.UglyNumberIII;

public class Solution
{
  private long LCM(long x, long y)
  {
    long a = x, b = y;
    while (a != 0)
    {
      long t = a;
      a = b % a;
      b = t;
    }
    return x * (y / b);
  }

  public int NthUglyNumber(int n, int a, int b, int c)
  {
    long lo = 1, hi = 2 * (long)Math.Pow(10, 9);
    long ab = LCM(a, b), bc = LCM(b, c), ca = LCM(c, a), abc = LCM(a, bc);
    while (lo <= hi)
    {
      long mid = (lo + hi) / 2;
      long count = mid / a + mid / b + mid / c - mid / ab - mid / bc - mid / ca + mid / abc;
      if (count >= n) hi = mid - 1;
      else lo = mid + 1;
    }
    return (int)lo;
  }
}
