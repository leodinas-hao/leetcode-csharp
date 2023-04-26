/*
Add digits
https://leetcode.com/problems/add-digits/

Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.

Example 1:
Input: num = 38
Output: 2
Explanation: The process is
38 --> 3 + 8 --> 11
11 --> 1 + 1 --> 2 
Since 2 has only one digit, return it.

Example 2:
Input: num = 0
Output: 0

Constraints:
0 <= num <= 2^31 - 1
*/

namespace LeetCode.AddDigits;


// check digital root: https://en.wikipedia.org/wiki/Digital_root
public class Solution
{
  public int AddDigits(int num)
  {
    if (num == 0) return 0;
    if (num % 9 == 0) return 9;
    return num % 9;
  }
}

public class Solution2
{
  public int AddDigits(int num)
  {
    int sum = 0;
    while (num > 0)
    {
      sum += num % 10;
      num = num / 10;

      if (num == 0 && sum > 9)
      {
        num = sum;
        sum = 0;
      }
    }
    return sum;
  }
}
