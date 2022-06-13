using LeetCode.SearchInRotatedSortedArray;

namespace tests;

public class SearchInRotatedSortedArrayTests
{
  [Theory]
  [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
  [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
  [InlineData(new int[] { 1 }, 0, -1)]
  public void Test1(int[] nums, int target, int expect)
  {
    var result = new Solution().Search(nums, target);
    Assert.Equal(expect, result);
  }
}