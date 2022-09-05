using LeetCode.SearchInRotatedSortedArrayII;

namespace tests;

public class SearchInRotatedSortedArrayIITests
{
  [Theory]
  [InlineData(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0, true)]
  [InlineData(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3, false)]
  public void Test1(int[] nums, int target, bool expect)
  {
    Assert.Equal(expect, new Solution().Search(nums, target));
  }
}