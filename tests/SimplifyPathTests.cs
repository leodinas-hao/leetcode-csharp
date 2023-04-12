using LeetCode.SimplifyPath;

namespace tests;

public class SimplifyPathTests
{
  [Theory]
  [InlineData("/home//foo/", "/home/foo")]
  [InlineData("/../", "/")]
  [InlineData("/home/", "/home")]
  public void Test1(string path, string expect)
  {
    var result = new Solution().SimplifyPath(path);
    Assert.Equal(expect, result);
  }
}
