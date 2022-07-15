/*
Coin Change
https://leetcode.com/problems/coin-change/

You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
You may assume that you have an infinite number of each kind of coin.

Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0

Constraints:
1 <= coins.length <= 12
1 <= coins[i] <= 2^31 - 1
0 <= amount <= 10^4
*/

namespace LeetCode.CoinChange;

public class Solution
{
  public int CoinChange(int[] coins, int amount)
  {
    // dp represents the fewest number of coins (as the array value) 
    // that needed to make up amount/as index
    var dp = new int[amount + 1];
    Array.Fill(dp, Int32.MaxValue);
    dp[0] = 0;  // 0 amount, 0 coins required

    for (int i = 1; i <= amount; i++)
    {
      for (int j = 0; j < coins.Length; j++)
      {
        int prev = i - coins[j];
        if (prev >= 0 && dp[prev] != Int32.MaxValue)
        {
          dp[i] = Math.Min(dp[i], 1 + dp[prev]);
        }
      }
    }

    return dp[amount] == Int32.MaxValue ? -1 : dp[amount];
  }
}
