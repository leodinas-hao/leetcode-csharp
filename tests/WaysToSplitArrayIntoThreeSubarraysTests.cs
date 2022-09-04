using LeetCode.WaysToSplitArrayIntoThreeSubarrays;

namespace tests;

public class WaysToSplitArrayIntoThreeSubarraysTests
{
  [Theory]
  [InlineData(new int[] { 1, 1, 1 }, 1)]
  [InlineData(new int[] { 1, 2, 2, 2, 5, 0 }, 3)]
  [InlineData(new int[] { 3, 2, 1 }, 0)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().WaysToSplit(nums));
  }
}
