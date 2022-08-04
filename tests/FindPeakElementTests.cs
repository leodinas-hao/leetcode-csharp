using LeetCode.FindPeakElement;

namespace tests;

public class FindPeakElementTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 1 }, new int[] { 2 })]
  [InlineData(new int[] { 1, 2, 1, 3, 5, 6, 4 }, new int[] { 1, 5 })]
  [InlineData(new int[] { 1, 2, 1, 1, 1 }, new int[] { 1, 4 })]
  public void Test1(int[] nums, int[] expect)
  {
    Assert.True(expect.Contains(new Solution().FindPeakElement(nums)));
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 1 }, new int[] { 2 })]
  [InlineData(new int[] { 1, 2, 1, 3, 5, 6, 4 }, new int[] { 1, 5 })]
  [InlineData(new int[] { 1, 2, 1, 1, 1 }, new int[] { 1, 4 })]
  public void Test2(int[] nums, int[] expect)
  {
    Assert.True(expect.Contains(new Solution2().FindPeakElement(nums)));
  }
}
