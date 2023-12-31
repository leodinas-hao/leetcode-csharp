using LeetCode.LargestSubstringBetweenTwoEqualCharacters;

namespace tests;

public class LargestSubstringBetweenTwoEqualCharactersTests
{
  [Theory]
  [InlineData("aa", 0)]
  [InlineData("abca", 2)]
  [InlineData("cbzxy", -1)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().MaxLengthBetweenEqualCharacters(s));
  }
}
