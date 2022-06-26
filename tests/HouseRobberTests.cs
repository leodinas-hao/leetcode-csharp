using LeetCode.HouseRobber;

namespace tests;

public class HouseRobberTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
  [InlineData(new int[] { 2, 7, 9, 3, 1 }, 12)]
  [InlineData(new int[] { 2, 1, 1, 2 }, 4)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().Rob(nums));
  }
}
