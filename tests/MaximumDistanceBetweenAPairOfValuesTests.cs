using LeetCode.MaximumDistanceBetweenAPairOfValues;

namespace tests;

public class MaximumDistanceBetweenAPairOfValuesTests
{
  [Theory]
  [InlineData(new int[] { 55, 30, 5, 4, 2 }, new int[] { 100, 20, 10, 10, 5 }, 2)]
  [InlineData(new int[] { 2, 2, 2 }, new int[] { 10, 10, 1 }, 1)]
  [InlineData(new int[] { 30, 29, 19, 5 }, new int[] { 25, 25, 25, 25, 25 }, 2)]
  public void Test1(int[] nums1, int[] nums2, int expect)
  {
    var max = new Solution().MaxDistance(nums1, nums2);
    Assert.Equal(expect, max);
  }

  [Theory]
  [InlineData(new int[] { 55, 30, 5, 4, 2 }, new int[] { 100, 20, 10, 10, 5 }, 2)]
  [InlineData(new int[] { 2, 2, 2 }, new int[] { 10, 10, 1 }, 1)]
  [InlineData(new int[] { 30, 29, 19, 5 }, new int[] { 25, 25, 25, 25, 25 }, 2)]
  public void Test2(int[] nums1, int[] nums2, int expect)
  {
    var max = new Solution2().MaxDistance(nums1, nums2);
    Assert.Equal(expect, max);
  }
}