using LeetCode.BackspaceStringCompare;

namespace tests;

public class BackspaceStringCompareTests
{
  [Theory]
  [InlineData("a#c", "b", false)]
  [InlineData("ab##", "c#d#", true)]
  [InlineData("ab#c", "ad#c", true)]
  [InlineData("xywrrmp", "xywrrmu#p", true)]
  public void Test1(string s, string t, bool expect)
  {
    Assert.Equal(expect, new Solution().BackspaceCompare(s, t));
  }
}