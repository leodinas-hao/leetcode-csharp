using LeetCode.MaximumNumberOfRemovableCharacters;

namespace tests;

public class MaximumNumberOfRemovableCharactersTests
{
  [Theory]
  [InlineData("abcab", "abc", new int[] { 0, 1, 2, 3, 4 }, 0)]
  [InlineData("abcbddddd", "abcd", new int[] { 3, 2, 1, 4, 5, 6 }, 1)]
  [InlineData("abcacb", "ab", new int[] { 3, 1, 0 }, 2)]
  public void Test1(string s, string p, int[] removable, int expect)
  {
    Assert.Equal(expect, new Solution().MaximumRemovals(s, p, removable));
  }

  [Theory]
  [InlineData("abcab", "abc", new int[] { 0, 1, 2, 3, 4 }, 0)]
  [InlineData("abcbddddd", "abcd", new int[] { 3, 2, 1, 4, 5, 6 }, 1)]
  [InlineData("abcacb", "ab", new int[] { 3, 1, 0 }, 2)]
  public void Test2(string s, string p, int[] removable, int expect)
  {
    Assert.Equal(expect, new Solution2().MaximumRemovals(s, p, removable));
  }
}
