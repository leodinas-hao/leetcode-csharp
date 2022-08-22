/*
Bitwise AND of Numbers Range
https://leetcode.com/problems/bitwise-and-of-numbers-range/

Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.

Example 1:
Input: left = 5, right = 7
Output: 4

Example 2:
Input: left = 0, right = 0
Output: 0

Example 3:
Input: left = 1, right = 2147483647
Output: 0

Constraints:
0 <= left <= right <= 2^31 - 1
*/

namespace LeetCode.BitwiseAndOfNumbersRange;

/*
consider the case the following cases as example
    i =    1     2
4 (100) >> 10 >> 1
5 (101) >> 10 >> 1
6 (110) >> 11 >> 1
---------------------------------
100 & 101 & 110 = 100 = (1 << 2)

    i =    1     2
2 (010) >> 01 >> 0
3 (011) >> 01 >> 0
4 (100) >> 10 >> 1
--------------------------------
010 & 011 & 100 = 0 = (0 << 2)

as such, the final output can only be 0 or a power of 2 (10, 100, etc.)
*/
public class Solution
{
  public int RangeBitwiseAnd(int left, int right)
  {
    int i = 0;

    while (left != right)
    {
      left >>= 1;
      right >>= 1;
      i++;
    }

    return left << i;
  }
}