/*
Calculate Money In Leetcode Bank
https://leetcode.com/problems/calculate-money-in-leetcode-bank/

Hercy wants to save money for his first car. He puts money in the Leetcode bank every day.

He starts by putting in $1 on Monday, the first day. Every day from Tuesday to Sunday, he will put in $1 more than the day before. 
On every subsequent Monday, he will put in $1 more than the previous Monday.
Given n, return the total amount of money he will have in the Leetcode bank at the end of the nth day.

Example 1:
Input: n = 4
Output: 10
Explanation: After the 4th day, the total is 1 + 2 + 3 + 4 = 10.

Example 2:
Input: n = 10
Output: 37
Explanation: After the 10th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4) = 37. 
             Notice that on the 2nd Monday, Hercy only puts in $2.

Example 3:
Input: n = 20
Output: 96
Explanation: After the 20th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4 + 5 + 6 + 7 + 8) + (3 + 4 + 5 + 6 + 7 + 8) = 96.
 
Constraints:
1 <= n <= 1000
*/

namespace LeetCode.CalculateMondayInLeetcodeBank;

// just brute force
public class Solution
{
  public int TotalMoney(int n)
  {
    int total = 0, monday = 0, cur = 0;
    for (int i = 0; i < n; i++)
    {
      if (i % 7 == 0) { cur = monday + 1; monday = cur; }
      else { cur++; }
      total += cur;
    }
    return total;
  }
}


// math
// each week add 7 more dollars than the previous week
public class Solution2
{
  public int TotalMoney(int n)
  {
    int k = n / 7;
    int f = 28;  // 28 dollars a week
    int l = 28 + (k - 1) * 7;
    int arithmeticSum = k * (f + l) / 2;

    int monday = 1 + k;
    int finalWeek = 0;
    for (int day = 0; day < n % 7; day++)
    {
      finalWeek += monday + day;
    }
    return arithmeticSum + finalWeek;
  }
}