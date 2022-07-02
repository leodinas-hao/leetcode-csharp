/*
Best Time to Buy and Sell Stock with Cooldown
https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/

You are given an array prices where prices[i] is the price of a given stock on the ith day.
Find the maximum profit you can achieve. You may complete as many transactions as you like 
(i.e., buy one and sell one share of the stock multiple times) with the following restrictions:
After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

Example 1:
Input: prices = [1,2,3,0,2]
Output: 3
Explanation: transactions = [buy, sell, cooldown, buy, sell]

Example 2:
Input: prices = [1]
Output: 0

Constraints:
1 <= prices.length <= 5000
0 <= prices[i] <= 1000
*/

namespace LeetCode.BestTimeToBuyAndSellStockWithCooldown;


public class Solution
{
  public int MaxProfit(int[] prices)
  {
    if (prices.Length <= 1) return 0;

    int[] profit = new int[prices.Length];
    profit[0] = 0;  // buy stock 1st day
    profit[1] = Math.Max(0, prices[1] - prices[0]); // sell stock 2nd day if price is higher

    for (int i = 2; i < prices.Length; i++)
    {
      // profit not change if not selling (buy/cooldown)
      profit[i] = profit[i - 1];

      // if day i is a sell day, then try to find a best buying day between [0, i-1]
      for (int j = 0; j < i; j++)
      {
        // when buying on day j, then previous profit needs to be on j-2 due to cooldown
        int preProfit = j >= 2 ? profit[j - 2] : 0;
        profit[i] = Math.Max(profit[i], preProfit + prices[i] - prices[j]);
      }
    }

    return profit[^1];
  }
}


public class Solution2
{
  public int MaxProfit(int[] prices)
  {
    if (prices.Length <= 1) return 0;

    int[] profit = new int[prices.Length];
    profit[0] = 0;  // buy stock 1st day
    profit[1] = Math.Max(0, prices[1] - prices[0]); // sell stock 2nd day if price is higher

    // profit[i-2] - prices[i]
    int diff = -prices[0];

    for (int i = 0; i < prices.Length; i++)
    {
      if (i < 2) diff = Math.Max(diff, -prices[i]);
      else
      {
        profit[i] = Math.Max(profit[i - 1], diff + prices[i]);
        diff = Math.Max(diff, profit[i - 2] - prices[i]);
      }
    }

    return profit[^1];
  }
}
