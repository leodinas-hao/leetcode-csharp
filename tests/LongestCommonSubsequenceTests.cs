using LeetCode.LongestCommonSubsequence;

namespace tests;

public class LongestCommonSubsequence
{
  [Theory]
  [InlineData("abc", "abc", 3)]
  [InlineData("abc", "def", 0)]
  [InlineData("abcde", "ace", 3)]
  public void Test1(string t1, string t2, int expect)
  {
    Assert.Equal(expect, new Solution().LongestCommonSubsequence(t1, t2));
  }
}