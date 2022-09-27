using LeetCode.DecodeString;

namespace tests;

public class DecodeStringTests
{
  [Theory]
  [InlineData("3[a]2[bc]", "aaabcbc")]
  [InlineData("3[a2[c]]", "accaccacc")]
  [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
  public void Test1(string s, string expect)
  {
    Assert.Equal(expect, new Solution().DecodeString(s));
  }
}
