using LeetCode.SellDiminishingValuedColoredBalls;

namespace tests;

public class SellDiminishingValuedColoredBallsTests
{
  [Theory]
  [InlineData(new int[] { 3, 5 }, 6, 19)]
  [InlineData(new int[] { 2, 5 }, 4, 14)]
  public void Test1(int[] inventory, int orders, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfit(inventory, orders));
  }
}
