using LeetCode.HouseRobberII;

namespace tests;

public class HouseRobberIITests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
  [InlineData(new int[] { 1, 2, 3 }, 3)]
  [InlineData(new int[] { 2, 3, 2 }, 3)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().Rob(nums));
  }
}