using LeetCode.PathCrossing;

namespace tests;

public class PathCrossingTests
{
  [Theory]
  [InlineData("NES", false)]
  [InlineData("NESWW", true)]
  public void Test1(string path, bool expect)
  {
    Assert.Equal(expect, new Solution().IsPathCrossing(path));
  }
}
