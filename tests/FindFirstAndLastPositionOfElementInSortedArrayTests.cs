using LeetCode.FindFirstAndLastPositionOfElementInSortedArray;

namespace tests;

public class FindFirstAndLastPositionOfElementInSortedArrayTests
{
  [Theory]
  [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new[] { 3, 4 })]
  [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1, -1 })]
  [InlineData(new int[] { }, 0, new[] { -1, -1 })]
  [InlineData(new int[] { 1 }, 1, new[] { 0, 0 })]
  public void Test1(int[] nums, int target, int[] expect)
  {
    int[] result = new Solution().SearchRange(nums, target);
    Assert.Equal(expect[0], result[0]);
    Assert.Equal(expect[1], result[1]);
  }
}
