using LeetCode.MostProfitAssigningWork;

namespace tests;

public class MostProfitAssigningWorkTests
{
  [Theory]
  [InlineData(new int[] { 2, 4, 6, 8, 10 }, new int[] { 10, 20, 30, 40, 50 }, new int[] { 4, 5, 6, 7 }, 100)]
  [InlineData(new int[] { 85, 47, 57 }, new int[] { 24, 66, 99 }, new int[] { 40, 25, 25 }, 0)]
  [InlineData(new int[] { 5, 50, 92, 21, 24, 70, 17, 63, 30, 53 }, new int[] { 68, 100, 3, 99, 56, 43, 26, 93, 55, 25 }, new int[] { 96, 3, 55, 30, 11, 58, 68, 36, 26, 1 }, 765)]
  public void Test1(int[] difficulty, int[] profit, int[] worker, int expect)
  {
    Assert.Equal(expect, new Solution().MaxProfitAssignment(difficulty, profit, worker));
  }
}
