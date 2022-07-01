using LeetCode.BestSightseeingPair;

namespace tests;

public class BestSightseeingPairTests
{
  [Theory]
  [InlineData(new int[] { 8, 1, 5, 2, 6 }, 11)]
  [InlineData(new int[] { 1, 2 }, 2)]
  [InlineData(new int[] { 1, 3, 5 }, 7)]
  [InlineData(new int[] { 7, 8, 8, 10 }, 17)]
  public void Test1(int[] values, int expect)
  {
    Assert.Equal(expect, new Solution().MaxScoreSightseeingPair(values));
  }

  [Theory]
  [InlineData(new int[] { 8, 1, 5, 2, 6 }, 11)]
  [InlineData(new int[] { 1, 2 }, 2)]
  [InlineData(new int[] { 1, 3, 5 }, 7)]
  [InlineData(new int[] { 7, 8, 8, 10 }, 17)]
  public void Test2(int[] values, int expect)
  {
    Assert.Equal(expect, new Solution2().MaxScoreSightseeingPair(values));
  }
}
