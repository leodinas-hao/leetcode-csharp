using LeetCode.BuyTwoChocolates;

namespace tests;

public class BuyTwoChocolatesTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 2 }, 3, 0)]
  [InlineData(new int[] { 3, 2, 3 }, 3, 3)]
  public void Test1(int[] prices, int money, int expect)
  {
    Assert.Equal(expect, new Solution().BuyChoco(prices, money));
  }
}