using LeetCode.CountingBits;

namespace tests;


public class CountingBitsTests
{
  [Theory]
  [InlineData(2, new int[] { 0, 1, 1 })]
  [InlineData(5, new int[] { 0, 1, 1, 2, 1, 2 })]
  public void Test1(int n, int[] expect)
  {
    var result = new Solution().CountBits(n);
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(2, new int[] { 0, 1, 1 })]
  [InlineData(5, new int[] { 0, 1, 1, 2, 1, 2 })]
  public void Test2(int n, int[] expect)
  {
    var result = new Solution2().CountBits(n);
    Assert.Equal(expect, result);
  }
}