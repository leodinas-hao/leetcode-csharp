using LeetCode.BestTimeToBuyAndSellStock;

namespace tests;

public class BestTimeToBuyAndSellStockTests
{
  [Theory]
  [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
  [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
  public void Test1(int[] prices, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfit(prices));
  }
}
