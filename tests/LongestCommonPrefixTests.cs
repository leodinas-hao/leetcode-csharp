using LeetCode.LongestCommonPrefix;

namespace tests;

public class LongestCommonPrefixTests
{
  [Theory]
  [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
  [InlineData(new string[] { "dog", "racecar", "car" }, "")]
  public void Test1(string[] strs, string expect)
  {
    Assert.Equal(expect, new Solution().LongestCommonPrefix(strs));
  }

  [Theory]
  [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
  [InlineData(new string[] { "dog", "racecar", "car" }, "")]
  [InlineData(new string[] { "ab", "a" }, "a")]
  public void Test2(string[] strs, string expect)
  {
    Assert.Equal(expect, new Solution2().LongestCommonPrefix(strs));
  }
}
