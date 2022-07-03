/*
Best Time to Buy and Sell Stock with Transaction Fee
https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/

You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.
Find the maximum profit you can achieve. You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.
Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

Example 1:
Input: prices = [1,3,2,8,4,9], fee = 2
Output: 8
Explanation: The maximum profit can be achieved by:
- Buying at prices[0] = 1
- Selling at prices[3] = 8
- Buying at prices[4] = 4
- Selling at prices[5] = 9
The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.

Example 2:
Input: prices = [1,3,7,5,10,3], fee = 3
Output: 6

Constraints:
1 <= prices.length <= 5 * 10^4
1 <= prices[i] < 5 * 10^4
0 <= fee < 5 * 10^4
*/

namespace LeetCode.BestTimeToBuyAndSellStockWithTransactionFee;


public class Solution
{
  public int MaxProfit(int[] prices, int fee)
  {
    // cash: cash made by selling the stock (as credit)
    // hold: stock holding in hand (as debt)
    int cash = 0, hold = -prices[0];
    for (int i = 1; i < prices.Length; i++)
    {
      // cash: either not selling (no change) or selling the stock (with transaction fee)
      cash = Math.Max(cash, hold + prices[i] - fee);
      // hold: either hold whatever holding(not buying new) or buying stock with today's price
      hold = Math.Max(hold, cash - prices[i]);
    }
    return cash;
  }
}

/*
DP
same concept as above, but maintain profits & buying prices in 2D array
each day we have three choice: buy stock or sell stock or do nothing
only two states each day: having a stock or not having a stock
*/
public class Solution2
{
  public int MaxProfit(int[] prices, int fee)
  {
    int n = prices.Length;

    // dp[i][0]: the maximum profit on i-th day not maintain a stock
    // dp[i][1]: the maximum profit on i-th day maintain a stock
    int[,] dp = new int[n, 2];
    dp[0, 0] = 0;
    dp[0, 1] = -prices[0];

    for (int i = 1; i < n; i++)
    {
      // do nothing or sell stock with last price dp[i-1,1]
      dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i] - fee);
      // do nothing or buy stock last profit dp[i-1,0]
      dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
    }
    return dp[n - 1, 0];
  }
}