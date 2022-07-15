using LeetCode.CoinChange;

namespace tests;

public class CoinChangeTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 5 }, 11, 3)]
  [InlineData(new int[] { 2 }, 3, -1)]
  [InlineData(new int[] { 1 }, 0, 0)]
  public void Test1(int[] coins, int amount, int expect)
  {
    Assert.Equal(expect, new Solution().CoinChange(coins, amount));
  }
}
