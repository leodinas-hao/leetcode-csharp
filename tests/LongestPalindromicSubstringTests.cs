using LeetCode.LongestPalindromicSubstring;

namespace tests;

public class LongestPalindromicSubstringTests
{
  [Theory]
  [InlineData("cbbd", "bb")]
  [InlineData("babad", "bab")]
  public void Test1(string s, string expect)
  {
    Assert.Equal(expect, new Solution().LongestPalindrome(s));
  }
}