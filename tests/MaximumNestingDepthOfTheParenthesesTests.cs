using LeetCode.MaximumNestingDepthOfTheParentheses;

namespace tests;


public class MaximumNestingDepthOfTheParenthesesTests
{
  [Theory]
  [InlineData("(1+(2*3)+((8)/4))+1", 3)]
  [InlineData("(1)+((2))+(((3)))", 3)]
  public void Test1(string s, int expect)
  {
    Assert.Equal(expect, new Solution().MaxDepth(s));
  }
}
