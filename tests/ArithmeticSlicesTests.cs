using LeetCode.ArithmeticSlices;

namespace tests;

public class ArithmeticSlicesTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, 3)]
  [InlineData(new int[] { 1 }, 0)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().NumberOfArithmeticSlices(nums));
  }
}
