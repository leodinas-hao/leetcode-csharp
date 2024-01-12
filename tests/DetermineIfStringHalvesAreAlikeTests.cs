using LeetCode.DetermineIfStringHalvesAreAlike;

namespace tests;

public class DetermineIfStringHalvesAreAlikeTests
{
  [Theory]
  [InlineData("book", true)]
  [InlineData("textbook", false)]
  public void Test1(string s, bool expect)
  {
    Assert.Equal(expect, new Solution().HalvesAreAlike(s));
  }
}