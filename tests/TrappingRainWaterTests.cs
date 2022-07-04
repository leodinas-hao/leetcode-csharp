using LeetCode.TrappingRainWater;

namespace tests;

public class TrappingRainWaterTests
{
  [Theory]
  [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
  [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
  public void Test1(int[] height, int expect)
  {
    Assert.Equal(expect, new Solution().Trap(height));
  }

  [Theory]
  [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
  [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
  public void Test2(int[] height, int expect)
  {
    Assert.Equal(expect, new Solution2().Trap(height));
  }

  [Theory]
  [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
  [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
  public void Test3(int[] height, int expect)
  {
    Assert.Equal(expect, new Solution3().Trap(height));
  }
}
