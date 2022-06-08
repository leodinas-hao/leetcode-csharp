using LeetCode.ArrangingCoins;

namespace tests;

public class ArrangingCoinsTests
{
  [Theory]
  [InlineData(8, 3)]
  [InlineData(5, 2)]
  [InlineData(1, 1)]
  public void Test1(int n, int expect)
  {
    int result = new Solution().ArrangeCoins(n);
    Assert.Equal(expect, result);
  }
}
