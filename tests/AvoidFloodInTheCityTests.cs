using LeetCode.AvoidFloodInTheCity;

namespace tests;

public class AvoidFloodInTheCityTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { -1, -1, -1, -1 })]
  [InlineData(new int[] { 1, 2, 0, 0, 2, 1 }, new int[] { -1, -1, 2, 1, -1, -1 })]
  [InlineData(new int[] { 1, 2, 0, 1, 2 }, new int[] { })]
  [InlineData(new int[] { 0, 1, 1 }, new int[] { })]
  public void Test1(int[] rains, int[] expect)
  {
    Assert.Equal(expect, new Solution().AvoidFlood(rains));
  }
}
