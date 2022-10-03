using LeetCode.PalindromeByConcatenatingTwoLetterWords;

namespace tests;

public class PalindromeByConcatenatingTwoLetterWordsTests
{
  [Theory]
  [InlineData(new string[] { "lc", "cl", "gg" }, 6)]
  [InlineData(new string[] { "ab", "ty", "yt", "lc", "cl", "ab" }, 8)]
  [InlineData(new string[] { "cc", "ll", "xx" }, 2)]
  public void Test1(string[] words, int expect)
  {
    Assert.Equal(expect, new Solution().LongestPalindrome(words));
  }
}
