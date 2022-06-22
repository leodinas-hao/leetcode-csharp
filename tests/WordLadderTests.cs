using LeetCode.WordLadder;

namespace tests;

public class WordLadderTests
{
  [Theory]
  [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }, 5)]
  [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }, 0)]
  public void Test1(string beginWord, string endWord, IList<string> wordList, int expect)
  {
    var result = new Solution().LadderLength(beginWord, endWord, wordList);
    Assert.Equal(expect, result);
  }
}