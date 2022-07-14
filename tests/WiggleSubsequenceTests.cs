using LeetCode.WiggleSubsequence;

namespace tests;

public class WiggleSubsequenceTests
{
  [Theory]
  [InlineData(new int[] { 1, 7, 4, 9, 2, 5 }, 6)]
  [InlineData(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }, 7)]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().WiggleMaxLength(nums));
  }

  [Theory]
  [InlineData(new int[] { 1, 7, 4, 9, 2, 5 }, 6)]
  [InlineData(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }, 7)]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().WiggleMaxLength(nums));
  }
}