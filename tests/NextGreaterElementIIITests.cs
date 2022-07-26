using LeetCode.NextGreaterElementIII;

namespace tests;

public class NextGreaterElementIIITests
{
  [Theory]
  [InlineData(12, 21)]
  [InlineData(21, -1)]
  [InlineData(230241, 230412)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().NextGreaterElement(n));
  }
}
