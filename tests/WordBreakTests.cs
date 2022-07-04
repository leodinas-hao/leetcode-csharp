using LeetCode.WordBreak;

namespace tests;

public class WordBreakTests
{
  [Theory]
  [InlineData("leetcode", new string[] { "leet", "code" }, true)]
  [InlineData("applepenapple", new string[] { "apple", "pen" }, true)]
  [InlineData("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }, false)]
  [InlineData("ccbb", new string[] { "bc", "cb" }, false)]
  [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
    new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, false)]
  public void Test1(string s, IList<string> wordDict, bool expect)
  {
    Assert.Equal(expect, new Solution().WordBreak(s, wordDict));
  }
}