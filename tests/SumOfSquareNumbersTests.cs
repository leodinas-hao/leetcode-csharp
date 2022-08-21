using LeetCode.SumOfSquareNumbers;

namespace tests;

public class SumOfSquareNumbersTests
{
  [Theory]
  [InlineData(5, true)]
  [InlineData(3, false)]
  public void Test1(int c, bool expect)
  {
    var result = new Solution().JudgeSquareSum(c);
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(5, true)]
  [InlineData(3, false)]
  public void Test2(int c, bool expect)
  {
    var result = new Solution2().JudgeSquareSum(c);
    Assert.Equal(expect, result);
  }
}
