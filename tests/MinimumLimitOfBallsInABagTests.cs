using LeetCode.MinimumLimitOfBallsInABag;

namespace tests;

public class MinimumLimitOfBallsInABagTests
{
  [Theory]
  [InlineData(new int[] { 7, 17 }, 2, 7)]
  [InlineData(new int[] { 2, 4, 8, 2 }, 4, 2)]
  [InlineData(new int[] { 9 }, 2, 3)]
  public void Test1(int[] nums, int max, int expect)
  {
    Assert.Equal(expect, new Solution().MinimumSize(nums, max));
  }
}