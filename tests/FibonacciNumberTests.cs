using LeetCode.FibonacciNumber;

namespace tests;

public class FibonacciNumberTests
{
  [Theory]
  [InlineData(3, 2)]
  [InlineData(4, 3)]
  [InlineData(2, 1)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().Fib(n));
  }
}