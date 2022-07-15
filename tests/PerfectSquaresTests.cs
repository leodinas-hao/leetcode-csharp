using LeetCode.PerfectSquares;

namespace tests;

public class PerfectSquaresTests
{
  [Theory]
  [InlineData(12, 3)]
  [InlineData(13, 2)]
  [InlineData(2, 2)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().NumSquares(n));
  }

  [Theory]
  [InlineData(12, 3)]
  [InlineData(13, 2)]
  [InlineData(1, 1)]
  public void Test2(int n, int expect)
  {
    Assert.Equal(expect, new Solution2().NumSquares(n));
  }

  [Theory]
  [InlineData(12, 3)]
  [InlineData(13, 2)]
  [InlineData(1, 1)]
  public void Test3(int n, int expect)
  {
    Assert.Equal(expect, new Solution3().NumSquares(n));
  }
}