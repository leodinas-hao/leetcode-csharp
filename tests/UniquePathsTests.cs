using LeetCode.UniquePaths;

namespace tests;

public class UniquePathsTests
{
  [Theory]
  [InlineData(3, 7, 28)]
  [InlineData(3, 2, 3)]
  public void Test1(int m, int n, int expect)
  {
    Assert.Equal(expect, new Solution().UniquePaths(m, n));
  }
}