using LeetCode.ReverseWordsInAString;

namespace tests;

public class ReverseWordsInAStringTests
{
  [Theory]
  [InlineData("the sky is blue", "blue is sky the")]
  [InlineData("  hello world  ", "world hello")]
  [InlineData("a good   example", "example good a")]
  public void Test1(string s, string expect)
  {
    Assert.Equal(expect, new Solution().ReverseWords(s));
  }

  [Theory]
  [InlineData("the sky is blue", "blue is sky the")]
  [InlineData("  hello world  ", "world hello")]
  [InlineData("a good   example", "example good a")]
  public void Test2(string s, string expect)
  {
    Assert.Equal(expect, new Solution2().ReverseWords(s));
  }
}