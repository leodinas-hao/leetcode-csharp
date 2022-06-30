using LeetCode.MaximumProductSubarray;

namespace tests;

public class MaximumProductSubarrayTests
{
  [Theory]
  [InlineData(new int[] { 1, -2, 3, -4, 5 }, 120)]
  [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
  [InlineData(new int[] { -2, 0, -1 }, 0)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProduct(nums));
  }

  [Theory]
  [InlineData(new int[] { 1, -2, 3, -4, 5 }, 120)]
  [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
  [InlineData(new int[] { -2, 0, -1 }, 0)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().MaxProduct(nums));
  }

  [Theory]
  [InlineData(new int[] { 1, -2, 3, -4, 5 }, 120)]
  [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
  [InlineData(new int[] { -2, 0, -1 }, 0)]
  public void Test3(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution3().MaxProduct(nums));
  }
}