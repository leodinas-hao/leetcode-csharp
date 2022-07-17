using LeetCode.ImplementStrStr;

namespace tests;

public class ImplementStrStrTests
{
  [Theory]
  [InlineData("hello", "ll", 2)]
  [InlineData("aaaaa", "bba", -1)]
  [InlineData("a", "a", 0)]
  [InlineData("abc", "c", 2)]
  [InlineData("mississippi", "issip", 4)]
  [InlineData("mississippi", "issipi", -1)]
  public void Test1(string haystack, string needle, int expect)
  {
    Assert.Equal(expect, new Solution().StrStr(haystack, needle));
  }
}
