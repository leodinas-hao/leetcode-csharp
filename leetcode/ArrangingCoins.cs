/*
Arranging coins
https://leetcode.com/problems/arranging-coins/

You have n coins and you want to build a staircase with these coins. The staircase consists of k rows where the ith row has exactly i coins. 
The last row of the staircase may be incomplete.

Given the integer n, return the number of complete rows of the staircase you will build.

Example 1:
@
@@
@@[]
Input: n = 5
Output: 2
Explanation: Because the 3rd row is incomplete, we return 2.

Example 2:
@
@@
@@@
@@[][]
Input: n = 8
Output: 3
Explanation: Because the 4th row is incomplete, we return 3.

Constraints:
1 <= n <= 2^31 - 1
*/

namespace LeetCode.ArrangingCoins;

/**
main idea of the solution is the sum of 1 to n equals "(1+n)*n/2"
1 + 2 + 3 + 4 = (1+4)*4/2 = 10, so 10 coins can form 4 rows
binary search between 0 & number n to find the rowth count
*/
public class Solution
{
  public int ArrangeCoins(int n)
  {
    long lo = 0, hi = n;
    while (lo <= hi)
    {
      long mid = lo + (hi - lo) / 2;
      long curr = mid * (mid + 1) / 2;
      if (curr == n) return (int)mid;
      if (curr < n) lo = mid + 1;
      else hi = mid - 1;
    }
    return (int)hi;
  }
}
