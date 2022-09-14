using LeetCode.FindPivotIndex;

namespace tests;

public class FindPivotIndexTests
{
  [Theory]
  [InlineData(new int[] { 2, 1, -1 }, 0)]
  [InlineData(new int[] { 1, 2, 3 }, -1)]
  [InlineData(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().PivotIndex(nums));
  }
}