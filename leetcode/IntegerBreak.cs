/*
Integer Break
https://leetcode.com/problems/integer-break/

Given an integer n, break it into the sum of k positive integers, where k >= 2, and maximize the product of those integers.
Return the maximum product you can get.

Example 1:
Input: n = 2
Output: 1
Explanation: 2 = 1 + 1, 1 × 1 = 1.

Example 2:
Input: n = 10
Output: 36
Explanation: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36.

Constraints:
2 <= n <= 58
*/

namespace LeetCode.IntegerBreak;

public class Solution
{
  public int IntegerBreak(int n)
  {
    if (n == 2) return 1;
    if (n == 3) return 2;

    int quotient = n / 3;
    int remainder = n % 3;
    if (remainder == 0)
      // (3^quotient)
      return (int)Math.Pow(3, quotient);
    else if (remainder == 1)
      // (3^(quotient-1))*(remainder+3)
      return (int)Math.Pow(3, (quotient - 1)) * (remainder + 3);
    else // remainder as 2
      // (3^quotient)*remainder
      return (int)Math.Pow(3, quotient) * remainder;
  }
}


public class Solution2
{
  public int IntegerBreak(int n)
  {
    int k = n, ans = 0;

    // loop 2<=k<=n
    while (k >= 2)
    {
      int q = n / k;
      int r = n % k;

      ans = (int)Math.Max(ans, Math.Pow(q + 1, r) * Math.Pow(q, k - r));

      k--;
    }

    return ans;
  }
}