using LeetCode.SubarrayProductLessThanK;

namespace tests;

public class SubarrayProductLessThanKTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, 0, 0)]
  [InlineData(new int[] { 10, 5, 2, 6 }, 100, 8)]
  public void Test1(int[] nums, int k, int expect)
  {
    Assert.Equal(expect, new Solution().NumSubarrayProductLessThanK(nums, k));
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, 0, 0)]
  [InlineData(new int[] { 10, 5, 2, 6 }, 100, 8)]
  public void Test2(int[] nums, int k, int expect)
  {
    Assert.Equal(expect, new Solution2().NumSubarrayProductLessThanK(nums, k));
  }
}
