using LeetCode.SingleNumber;

namespace tests;

public class SingleNumberTests
{
  [Theory]
  [InlineData(new int[] { 2, 2, 1 }, 1)]
  [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
  [InlineData(new int[] { 1 }, 1)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().SingleNumber(nums));
  }

  [Theory]
  [InlineData(new int[] { 2, 2, 1 }, 1)]
  [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
  [InlineData(new int[] { 1 }, 1)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().SingleNumber(nums));
  }
}