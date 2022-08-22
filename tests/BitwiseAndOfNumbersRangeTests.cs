using LeetCode.BitwiseAndOfNumbersRange;

namespace tests;

public class BitwiseAndOfNumbersRangeTests
{
  [Theory]
  [InlineData(5, 7, 4)]
  [InlineData(0, 0, 0)]
  [InlineData(1, 2147483647, 0)]
  [InlineData(2, 4, 0)]
  public void Test1(int left, int right, int expect)
  {
    Assert.Equal(expect, new Solution().RangeBitwiseAnd(left, right));
  }
}