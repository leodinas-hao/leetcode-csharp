using LeetCode.MaximumSubarray;

namespace tests;

public class MaximumSubarrayTests
{
  [Theory]
  [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
  [InlineData(new int[] { 1 }, 1)]
  [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().MaxSubArray(nums));
  }
}