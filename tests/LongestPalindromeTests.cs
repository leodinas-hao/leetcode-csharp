using LeetCode.LongestPalindrome;

namespace tests;

public class LongestPalindromeTests
{
  [Theory]
  [InlineData("a", 1)]
  [InlineData("abccccdd", 7)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().LongestPalindrome(s));
  }
}