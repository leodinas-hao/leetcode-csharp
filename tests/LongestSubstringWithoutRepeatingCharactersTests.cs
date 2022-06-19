using LeetCode.LongestSubstringWithoutRepeatingCharacters;

namespace tests;

public class LongestSubstringWithoutRepeatingCharactersTests
{
  [Theory]
  [InlineData("abcabcbb", 3)]
  [InlineData("bbbbb", 1)]
  [InlineData("pwwkew", 3)]
  [InlineData("tmmzuxt", 5)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().LengthOfLongestSubstring(s));
  }
}
