using LeetCode.IsomorphicStrings;

namespace tests;

public class IsomorphicStringsTests
{
  [Theory]
  [InlineData("egg", "add", true)]
  [InlineData("foo", "bar", false)]
  [InlineData("paper", "title", true)]
  [InlineData("badc", "baba", false)]
  [InlineData("abcdefghijklmnopqrstuvwxyzva", "abcdefghijklmnopqrstuvwxyzck", false)]
  public void Test1(string s, string t, bool expect)
  {
    Assert.Equal(expect, new Solution().IsIsomorphic(s, t));
  }
}
