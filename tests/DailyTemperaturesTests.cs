using LeetCode.DailyTemperatures;

namespace tests;

public class DailyTemperaturesTests
{
  [Theory]
  [InlineData(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new int[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
  [InlineData(new int[] { 30, 40, 50, 60 }, new int[] { 1, 1, 1, 0 })]
  [InlineData(new int[] { 30, 60, 90 }, new int[] { 1, 1, 0 })]
  public void Test1(int[] temperatures, int[] expect)
  {
    Assert.Equal(expect, new Solution().DailyTemperatures(temperatures));
  }
}