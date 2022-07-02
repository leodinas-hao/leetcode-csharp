using LeetCode.BestTimeToBuyAndSellStockWithCooldown;

namespace tests;

public class BestTimeToBuyAndSellStockWithCooldownTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 0, 2 }, 3)]
  [InlineData(new int[] { 1 }, 0)]
  [InlineData(new int[] { 1, 2, 4 }, 3)]
  public void Test1(int[] prices, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfit(prices));
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 0, 2 }, 3)]
  [InlineData(new int[] { 1 }, 0)]
  [InlineData(new int[] { 1, 2, 4 }, 3)]
  public void Test2(int[] prices, int expect)
  {
    Assert.Equal(expect, new Solution2().MaxProfit(prices));
  }
}
