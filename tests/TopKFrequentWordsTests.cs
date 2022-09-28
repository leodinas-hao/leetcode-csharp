using LeetCode.TopKFrequentWords;

namespace tests;

public class TopKFrequentWordsTests
{
  [Theory]
  [InlineData(new string[] { "i", "love", "leetcode", "i", "love", "coding" }, 2, new string[] { "i", "love" })]
  [InlineData(new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4, new string[] { "the", "is", "sunny", "day" })]
  public void Test1(string[] words, int k, string[] expect)
  {
    Assert.Equal(expect, new Solution().TopKFrequent(words, k));
  }
}
