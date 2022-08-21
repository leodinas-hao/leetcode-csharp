/*
Sum of Square Numbers
https://leetcode.com/problems/sum-of-square-numbers/

Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.

Example 1:
Input: c = 5
Output: true
Explanation: 1 * 1 + 2 * 2 = 5

Example 2:
Input: c = 3
Output: false

Constraints:
0 <= c <= 2^31 - 1
*/

namespace LeetCode.SumOfSquareNumbers;

/*
binary search to find if the square root is an integer
*/
public class Solution
{
  private bool Search(long lo, long hi, long target)
  {
    // binary search to see if the target has an integer square root
    if (lo > hi)
    {
      return false; // reached the high end, stop search
    }
    long mid = lo + (hi - lo) / 2;
    var sqr = mid * mid;
    if (sqr == target) return true; // find matching b
    if (sqr > target) return Search(lo, mid - 1, target);
    return Search(mid + 1, hi, target);
  }
  public bool JudgeSquareSum(int c)
  {
    // consider c = a * a + b * b
    // iterate from 0 to a number square, which less than c
    for (long a = 0; a * a <= c; a++)
    {
      // calculate the b value
      long b = c - (a * a);
      // binary search if b has an integer sqrt
      if (Search(0, b, b)) return true;
    }
    return false;
  }
}

/*
using `sqrt` function
*/
public class Solution2
{
  public bool JudgeSquareSum(int c)
  {
    // consider c = a * a + b * b
    // iterate from 0 to a number square, which less than c
    for (long a = 0; a * a <= c; a++)
    {
      // calculate the b value
      double b = Math.Sqrt(c - (a * a));
      // check if b is integer
      if (b == (int)b) return true;
    }
    return false;
  }
}
