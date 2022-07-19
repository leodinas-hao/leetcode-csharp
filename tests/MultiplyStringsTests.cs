using LeetCode.MultiplyStrings;

namespace tests;

public class MultiplyStringsTests
{
  [Theory]
  [InlineData("2", "3", "6")]
  [InlineData("123", "456", "56088")]
  public void Test1(string num1, string num2, string expect)
  {
    Assert.Equal(expect, new Solution().Multiply(num1, num2));
  }
}
