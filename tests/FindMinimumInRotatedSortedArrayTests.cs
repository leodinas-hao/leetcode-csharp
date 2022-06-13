using LeetCode.FindMinimumInRotatedSortedArray;

namespace tests;

public class FindMinimumInRotatedSortedArrayTests
{
  [Theory]
  [InlineData(new int[] { 3, 4, 5, 1, 2 }, 1)]
  [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
  [InlineData(new int[] { 11, 13, 15, 17 }, 11)]
  public void Test1(int[] nums, int expect)
  {
    var result = new Solution().FindMin(nums);
    Assert.Equal(expect, result);
  }
}
