using LeetCode.AssignCookies;

namespace tests;

public class AssignCookiesTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 1 }, 1)]
  [InlineData(new int[] { 1, 2 }, new int[] { 1, 2, 3 }, 2)]
  public void Test1(int[] g, int[] s, int expect)
  {
    Assert.Equal(expect, new Solution().FindContentChildren(g, s));
  }
}
