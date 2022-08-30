using LeetCode.MinimumSpeedToArriveOnTime;

namespace tests;

public class MinimumSpeedToArriveOnTimeTests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 2 }, 6, 1)]
  [InlineData(new int[] { 1, 3, 2 }, 2.7, 3)]
  [InlineData(new int[] { 1, 3, 2 }, 1.9, -1)]
  [InlineData(new int[] { 1, 1, 100000 }, 2.01, 10000000)]
  public void Test1(int[] dist, double hour, int expect)
  {
    Assert.Equal(expect, new Solution().MinSpeedOnTime(dist, hour));
  }
}