using LeetCode.MakeTheStringGreat;

namespace tests;

public class MakeTheStringGreatTests
{
  [Theory]
  [InlineData("s", "s")]
  [InlineData("abBAcC", "")]
  [InlineData("leEeetcode", "leetcode")]
  public void Test1(string s, string expect)
  {
    Assert.Equal(expect, new Solution().MakeGood(s));
  }

  [Theory]
  [InlineData("s", "s")]
  [InlineData("abBAcC", "")]
  [InlineData("leEeetcode", "leetcode")]
  public void Test2(string s, string expect)
  {
    Assert.Equal(expect, new Solution2().MakeGood(s));
  }
}