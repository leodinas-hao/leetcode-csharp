using LeetCode.MinimumSizeSubarraySum;

namespace tests;

public class MinimumSizeSubarraySumTests
{
  [Theory]
  [InlineData(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2)]
  [InlineData(4, new int[] { 1, 4, 4 }, 1)]
  [InlineData(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0)]
  public void Test1(int target, int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().MinSubArrayLen(target, nums));
  }
}