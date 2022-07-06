using LeetCode.UglyNumberII;

namespace tests;

public class UglyNumberIITests
{
  [Theory]
  [InlineData(10, 12)]
  [InlineData(1, 1)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().NthUglyNumber(n));
  }
}