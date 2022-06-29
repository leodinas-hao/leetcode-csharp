/*
Subtract the Product and Sum of Digits of an Integer
https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/

Given an integer number n, return the difference between the product of its digits and the sum of its digits.

Example 1:
Input: n = 234
Output: 15 
Explanation: 
Product of digits = 2 * 3 * 4 = 24 
Sum of digits = 2 + 3 + 4 = 9 
Result = 24 - 9 = 15

Example 2:
Input: n = 4421
Output: 21
Explanation: 
Product of digits = 4 * 4 * 2 * 1 = 32 
Sum of digits = 4 + 4 + 2 + 1 = 11 
Result = 32 - 11 = 21

Constraints:
1 <= n <= 10^5
*/

namespace LeetCode.SubtractTheProductAndSumOfDigitsOfAnInteger;

public class Solution
{
  private IList<int> GetDigits(int n)
  {
    var digits = new List<int>();
    while (n != 0)
    {
      int d = n % 10;
      digits.Add(d);

      n = n / 10;
    }
    return digits;
  }

  public int SubtractProductAndSum(int n)
  {
    var digits = GetDigits(n);
    int sum = 0, pro = 1;
    foreach (var d in digits)
    {
      sum += d;
      pro *= d;
    }
    return pro - sum;
  }
}