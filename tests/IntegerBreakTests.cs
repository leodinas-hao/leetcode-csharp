using LeetCode.IntegerBreak;

namespace tests;

public class IntegerBreakTests
{
  [Theory]
  [InlineData(2, 1)]
  [InlineData(10, 36)]
  [InlineData(7, 12)]
  [InlineData(8, 18)]
  [InlineData(9, 27)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().IntegerBreak(n));
  }

  [Theory]
  [InlineData(2, 1)]
  [InlineData(10, 36)]
  [InlineData(7, 12)]
  [InlineData(8, 18)]
  [InlineData(9, 27)]
  public void Test2(int n, int expect)
  {
    Assert.Equal(expect, new Solution2().IntegerBreak(n));
  }
}
