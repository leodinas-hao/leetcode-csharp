/*
ugly number
https://leetcode.com/problems/ugly-number/

An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
Given an integer n, return true if n is an ugly number.

Example 1:
Input: n = 6
Output: true
Explanation: 6 = 2 × 3

Example 2:
Input: n = 1
Output: true
Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.

Example 3:
Input: n = 14
Output: false
Explanation: 14 is not ugly since it includes the prime factor 7.

Constraints:
-231 <= n <= 231 - 1
*/

namespace LeetCode.UglyNumber;

public class Solution
{
  public bool IsUgly(int n)
  {
    if (n <= 0) return false;

    var factors = new int[] { 2, 3, 5 };

    foreach (var f in factors)
    {
      n = KeepDividingWhenDivisible(n, f);
    }

    return n == 1;
  }

  private int KeepDividingWhenDivisible(int dividend, int divisor)
  {
    while (dividend % divisor == 0)
    {
      dividend /= divisor;
    }
    return dividend;
  }
}