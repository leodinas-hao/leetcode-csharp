using LeetCode.UniqueBinarySearchTrees;

namespace tests;

public class UniqueBinarySearchTreesTests
{
  [Theory]
  [InlineData(3, 5)]
  [InlineData(1, 1)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().NumTrees(n));
  }
}
