/*
Power of Two
https://leetcode.com/problems/power-of-two/

Given an integer n, return true if it is a power of two. Otherwise, return false.

An integer n is a power of two, if there exists an integer x such that n == 2x.

Example 1:
Input: n = 1
Output: true
Explanation: 20 = 1

Example 2:
Input: n = 16
Output: true
Explanation: 24 = 16

Example 3:
Input: n = 3
Output: false

Constraints:
-2^31 <= n <= 2^31 - 1
*/


namespace LeetCode.PowerOfTwo;

public class Solution
{
  public bool IsPowerOfTwo(int n)
  {
    if (n <= 0) return false;

    return (int)(Math.Ceiling((Math.Log(n) / Math.Log(2)))) ==
           (int)(Math.Floor(((Math.Log(n) / Math.Log(2)))));
  }
}

public class Solution2
{
  public bool IsPowerOfTwo(int n)
  {
    if (n <= 0) return false;
    while (n != 1)
    {
      if (n % 2 != 0) return false;
      n = n / 2;
    }
    return true;
  }
}

/*
if a number is a power of two, then in bitwise this number should be like:
1 -> 1
2 -> 10
4 -> 100
8 -> 1000
16 -> 10000
32 -> 100000

then n-1 in bitwise would be like:
4-1 = 3 -> 011
16-1 = 15 -> 01111

so bitwise n & (n-1) == 0
exclude n <= 0 as they are not a power of 2
*/
public class Solution3
{
  public bool IsPowerOfTwo(int n)
  {
    if (n <= 0) return false; // remove edge cases
    return (n & (n - 1)) == 0;
  }
}