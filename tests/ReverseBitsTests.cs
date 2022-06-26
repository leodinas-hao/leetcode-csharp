using LeetCode.ReverseBits;

namespace tests;

public class ReverseBitsTests
{
  [Theory]
  [InlineData(0b0000_0010_1001_0100_0001_1110_1001_1100, 0b0011_1001_0111_1000_0010_1001_0100_0000)]
  [InlineData(0b1111_1111_1111_1111_1111_1111_1111_1101, 0b1011_1111_1111_1111_1111_1111_1111_1111)]
  public void Test1(uint n, uint expect)
  {
    Assert.Equal(expect, new Solution().reverseBits(n));
  }
}