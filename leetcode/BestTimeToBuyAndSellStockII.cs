/*
Best Time to Buy and Sell Stock II
https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. 
However, you can buy it then immediately sell it on the same day.
Find and return the maximum profit you can achieve.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.

Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.

Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.

Constraints:
1 <= prices.length <= 3 * 10^4
0 <= prices[i] <= 10^4
*/

namespace LeetCode.BestTimeToBuyAndSellStockII;

/*
greedy approach
buy stock everyday and if next day price increased, then sell and buy again
*/
public class Solution
{
  public int MaxProfit(int[] prices)
  {
    if (prices.Length <= 1) return 0;
    int buy = prices[0], temp, profit = 0;
    for (int i = 1; i < prices.Length; i++)
    {
      temp = prices[i] - buy;
      buy = prices[i];
      profit += temp > 0 ? temp : 0;
    }
    return profit;
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

    for (int i = 2; i < prices.Length; i++)
    {
      // if not selling on day i, profit remains as last day
      profit[i] = profit[i - 1];

      // if day i is selling, then try to find a best buying day between [0, i-1]
      for (int j = 0; j < i; j++)
      {
        int preProfit = j >= 1 ? profit[j - 1] : 0;
        profit[i] = Math.Max(profit[i], preProfit + prices[i] - prices[j]);
      }
    }

    return profit[^1];
  }
}
