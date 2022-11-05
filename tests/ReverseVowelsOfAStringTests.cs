using LeetCode.ReverseVowelsOfAString;

namespace tests;

public class ReverseVowelsOfAStringTests
{
  [Theory]
  [InlineData("hello", "holle")]
  [InlineData("leetcode", "leotcede")]
  public void Test1(string s, string expect)
  {
    Assert.Equal(expect, new Solution().ReverseVowels(s));
  }
}