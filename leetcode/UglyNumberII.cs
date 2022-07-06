/*
Ugly Number II
https://leetcode.com/problems/ugly-number-ii/

An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
Given an integer n, return the nth ugly number.

Example 1:
Input: n = 10
Output: 12
Explanation: [1, 2, 3, 4, 5, 6, 8, 9, 10, 12] is the sequence of the first 10 ugly numbers.

Example 2:
Input: n = 1
Output: 1
Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.

Constraints:
1 <= n <= 1690
*/

namespace LeetCode.UglyNumberII;

public class Solution
{
  public int NthUglyNumber(int n)
  {
    var ans = new int[n];

    ans[0] = 1;
    int p2 = 0, p3 = 0, p5 = 0;
    for (int i = 1; i < n; i++)
    {
      ans[i] = new int[] { ans[p2] * 2, ans[p3] * 3, ans[p5] * 5 }.Min();

      if (ans[p2] * 2 == ans[i]) p2++;
      if (ans[p3] * 3 == ans[i]) p3++;
      if (ans[p5] * 5 == ans[i]) p5++;
    }
    return ans[n - 1];
  }
}

