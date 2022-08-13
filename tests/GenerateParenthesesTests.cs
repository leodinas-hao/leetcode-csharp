using LeetCode.GenerateParentheses;

namespace tests;

public class GenerateParenthesesTests
{
  [Theory]
  [InlineData(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
  [InlineData(1, new string[] { "()" })]
  public void Test1(int n, string[] expect)
  {
    var result = new Solution().GenerateParenthesis(n);
    Assert.Equal(expect.Length, result.Count);
    Assert.False(expect.Except(result).Any());
  }
}
