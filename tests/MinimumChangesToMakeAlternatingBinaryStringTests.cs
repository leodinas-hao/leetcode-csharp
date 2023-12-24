using LeetCode.MinimumChangesToMakeAlternatingBinaryString;

namespace tests;

public class MinimumChangesToMakeAlternatingBinaryStringTests
{
  [Theory]
  [InlineData("0100", 1)]
  [InlineData("10", 0)]
  [InlineData("1111", 2)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().MinOperations(s));
  }
}