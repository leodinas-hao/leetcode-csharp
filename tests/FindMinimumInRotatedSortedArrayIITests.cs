using LeetCode.FindMinimumInRotatedSortedArrayII;

namespace tests;

public class FindMinimumInRotatedSortedArrayIITests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 5 }, 1)]
  [InlineData(new int[] { 2, 2, 2, 0, 1 }, 0)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().FindMin(nums));
  }
}