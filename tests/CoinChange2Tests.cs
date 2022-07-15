using LeetCode.CoinChange2;

namespace tests;

public class CoinChange2Tests
{
  [Theory]
  [InlineData(5, new int[] { 1, 2, 5 }, 4)]
  [InlineData(3, new int[] { 2 }, 0)]
  [InlineData(10, new int[] { 10 }, 1)]
  public void Test1(int amount, int[] coins, int expect)
  {
    Assert.Equal(expect, new Solution().Change(amount, coins));
  }
}
