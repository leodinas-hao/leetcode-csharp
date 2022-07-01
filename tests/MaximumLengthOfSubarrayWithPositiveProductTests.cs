using LeetCode.MaximumLengthOfSubarrayWithPositiveProduct;

namespace tests;

public class MaximumLengthOfSubarrayWithPositiveProductTests
{
  [Theory]
  [InlineData(new int[] { 1, -2, -3, 4 }, 4)]
  [InlineData(new int[] { 0, 1, -2, -3, -4 }, 3)]
  [InlineData(new int[] { -1, -2, -3, 0, 1 }, 2)]
  [InlineData(new int[] { -1, 2 }, 1)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().GetMaxLen(nums));
  }
}