using LeetCode.LongestPalindromicSubsequence;

namespace tests;

public class LongestPalindromicSubsequenceTests
{
  [Theory]
  [InlineData("bbbab", 4)]
  [InlineData("cbbd", 2)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().LongestPalindromeSubseq(s));
  }
}