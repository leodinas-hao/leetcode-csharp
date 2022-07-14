using LeetCode.IsSubsequence;

namespace tests;


public class IsSubsequenceTests
{
  [Theory]
  [InlineData("abc", "ahbgdc", true)]
  [InlineData("axc", "ahbgdc", false)]
  public void Test1(string s, string t, bool expect)
  {
    Assert.Equal(expect, new Solution().IsSubsequence(s, t));
  }
}
