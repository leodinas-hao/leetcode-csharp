using LeetCode.VerifyingAnAlienDictionary;

namespace tests;

public class VerifyingAnAlienDictionaryTests
{
  [Theory]
  [InlineData(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
  [InlineData(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
  [InlineData(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
  public void Test1(string[] words, string order, bool expect)
  {
    Assert.Equal(expect, new Solution().IsAlienSorted(words, order));
  }
}
