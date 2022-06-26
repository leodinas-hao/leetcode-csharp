using LeetCode.NumberOfOneBits;

namespace tests;

public class NumberOfOneBitsTests
{
  [Theory]
  [InlineData(0b1011, 3)]
  [InlineData(0b10000000, 1)]
  [InlineData(0b11111111111111111111111111111101, 31)]
  public void Test1(uint n, int expect)
  {
    Assert.Equal(expect, new Solution().HammingWeight(n));
  }
}