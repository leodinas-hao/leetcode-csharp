using LeetCode.NthTribonacciNumber;

namespace tests;

public class NthTribonacciNumberTests
{
  [Theory]
  [InlineData(4, 4)]
  [InlineData(25, 1389537)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().Tribonacci(n));
  }
}
