using LeetCode.MaximumScoreAfterSplittingAString;

namespace tests;

public class MaximumScoreAfterSplittingAStringTests
{
  [Theory]
  [InlineData("011101", 5)]
  [InlineData("00111", 5)]
  [InlineData("1111", 3)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().MaxScore(s));
  }
}