using LeetCode.RepeatedSubstringPattern;

namespace tests;

public class RepeatedSubstringPatternTests
{
  [Theory]
  [InlineData("abab", true)]
  [InlineData("aba", false)]
  [InlineData("abcabcabcabc", true)]
  public void Test1(string s, bool expect)
  {
    Assert.Equal(expect, new Solution().RepeatedSubstringPattern(s));
  }

  [Theory]
  [InlineData("abab", true)]
  [InlineData("aba", false)]
  [InlineData("abcabcabcabc", true)]
  public void Test2(string s, bool expect)
  {
    Assert.Equal(expect, new Solution2().RepeatedSubstringPattern(s));
  }
}