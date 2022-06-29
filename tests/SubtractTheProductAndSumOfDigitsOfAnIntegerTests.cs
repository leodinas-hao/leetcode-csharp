using LeetCode.SubtractTheProductAndSumOfDigitsOfAnInteger;

namespace tests;

public class SubtractTheProductAndSumOfDigitsOfAnIntegerTests
{
  [Theory]
  [InlineData(234, 15)]
  [InlineData(4421, 21)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().SubtractProductAndSum(n));
  }
}