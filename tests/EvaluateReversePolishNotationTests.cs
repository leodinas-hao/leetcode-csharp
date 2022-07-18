using LeetCode.EvaluateReversePolishNotation;

namespace tests;

public class EvaluateReversePolishNotationTests
{
  [Theory]
  [InlineData(new string[] { "2", "1", "+", "3", "*" }, 9)]
  [InlineData(new string[] { "4", "13", "5", "/", "+" }, 6)]
  [InlineData(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
  public void Test1(string[] tokens, int expect)
  {
    Assert.Equal(expect, new Solution().EvalRPN(tokens));
  }
}