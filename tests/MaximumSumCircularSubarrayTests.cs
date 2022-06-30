using LeetCode.MaximumSumCircularSubarray;

namespace tests;

public class MaximumSumCircularSubarrayTests
{
  [Theory]
  [InlineData(new int[] { -3, -2, -3 }, -2)]
  [InlineData(new int[] { 5, -3, 5 }, 10)]
  [InlineData(new int[] { 1, -2, 3, -2 }, 3)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().MaxSubarraySumCircular(nums));
  }
}