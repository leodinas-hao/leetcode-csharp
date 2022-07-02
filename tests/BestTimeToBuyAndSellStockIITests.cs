using LeetCode.BestTimeToBuyAndSellStockII;

namespace tests;

public class BestTimeToBuyAndSellStockIITests
{
  [Theory]
  [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
  [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
  public void Test1(int[] prices, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfit(prices));
  }

  [Theory]
  [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
  [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
  public void Test2(int[] prices, int expect)
  {
    Assert.Equal(expect, new Solution2().MaxProfit(prices));
  }
}