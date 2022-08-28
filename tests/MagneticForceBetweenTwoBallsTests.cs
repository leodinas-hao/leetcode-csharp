using LeetCode.MagneticForceBetweenTwoBalls;

namespace tests;

public class MagneticForceBetweenTwoBallsTests
{
  [Theory]
  [InlineData(new int[] { 5, 4, 3, 2, 1, 1000000000 }, 2, 999999999)]
  [InlineData(new int[] { 1, 2, 3, 4, 7 }, 3, 3)]
  public void Test1(int[] position, int m, int expect)
  {
    Assert.Equal(expect, new Solution().MaxDistance(position, m));
  }
}
