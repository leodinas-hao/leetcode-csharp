using LeetCode.NextGreaterElementII;

namespace tests;

public class NextGreaterElementIITests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 1 }, new int[] { 2, -1, 2 })]
  [InlineData(new int[] { 1, 2, 3, 4, 3 }, new int[] { 2, 3, 4, -1, 4 })]
  [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { -1, 5, 5, 5, 5 })]
  public void Test1(int[] nums, int[] expect)
  {
    Assert.Equal(expect, new Solution().NextGreaterElements(nums));
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 1 }, new int[] { 2, -1, 2 })]
  [InlineData(new int[] { 1, 2, 3, 4, 3 }, new int[] { 2, 3, 4, -1, 4 })]
  [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { -1, 5, 5, 5, 5 })]
  public void Test2(int[] nums, int[] expect)
  {
    Assert.Equal(expect, new Solution2().NextGreaterElements(nums));
  }
}
