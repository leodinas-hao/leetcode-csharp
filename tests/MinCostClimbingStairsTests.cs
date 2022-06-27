using LeetCode.MinCostClimbingStairs;

namespace tests;

public class MinCostClimbingStairsTests
{
  [Theory]
  [InlineData(new int[] { 10, 15, 20 }, 15)]
  [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
  public void Test1(int[] cost, int expect)
  {
    Assert.Equal(expect, new Solution().MinCostClimbingStairs(cost));
  }

  [Theory]
  [InlineData(new int[] { 10, 15, 20 }, 15)]
  [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
  public void Test2(int[] cost, int expect)
  {
    Assert.Equal(expect, new Solution2().MinCostClimbingStairs(cost));
  }
}
