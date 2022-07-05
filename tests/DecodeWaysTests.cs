using LeetCode.DecodeWays;

namespace tests;

public class DecodeWaysTests
{
  [Theory]
  [InlineData("12", 2)]
  [InlineData("226", 3)]
  [InlineData("06", 0)]
  [InlineData("32102", 1)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().NumDecodings(s));
  }
}
