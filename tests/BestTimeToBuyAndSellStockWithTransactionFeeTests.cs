using LeetCode.BestTimeToBuyAndSellStockWithTransactionFee;

namespace tests;

public class BestTimeToBuyAndSellStockWithTransactionFeeTests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 7, 5, 10, 3 }, 3, 6)]
  [InlineData(new int[] { 1, 3, 2, 8, 4, 9 }, 2, 8)]
  public void Test1(int[] prices, int fee, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfit(prices, fee));
  }

  [Theory]
  [InlineData(new int[] { 1, 3, 7, 5, 10, 3 }, 3, 6)]
  [InlineData(new int[] { 1, 3, 2, 8, 4, 9 }, 2, 8)]
  public void Test2(int[] prices, int fee, int expect)
  {
    Assert.Equal(expect, new Solution2().MaxProfit(prices, fee));
  }
}