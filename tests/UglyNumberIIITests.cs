using LeetCode.UglyNumberIII;

namespace tests;

public class UglyNumberIIITests
{
  [Theory]
  [InlineData(3, 2, 3, 5, 4)]
  [InlineData(4, 2, 3, 4, 6)]
  [InlineData(5, 2, 11, 13, 10)]
  public void Test1(int n, int a, int b, int c, int expect)
  {
    Assert.Equal(expect, new Solution().NthUglyNumber(n, a, b, c));
  }
}
