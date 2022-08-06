using LeetCode.ContainerWithMostWater;

namespace tests;

public class ContainerWithMostWaterTests
{
  [Theory]
  [InlineData(new int[] { 1, 1 }, 1)]
  [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
  public void Test1(int[] height, int expect)
  {
    Assert.Equal(expect, new Solution().MaxArea(height));
  }
}
