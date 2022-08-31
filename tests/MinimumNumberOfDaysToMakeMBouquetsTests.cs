using LeetCode.MinimumNumberOfDaysToMakeMBouquets;

namespace tests;

public class MinimumNumberOfDaysToMakeMBouquetsTests
{
  [Theory]
  [InlineData(new int[] { 1, 10, 3, 10, 2 }, 3, 1, 3)]
  [InlineData(new int[] { 1, 10, 3, 10, 2 }, 3, 2, -1)]
  [InlineData(new int[] { 7, 7, 7, 7, 12, 7, 7 }, 2, 3, 12)]
  public void Test1(int[] bloomDay, int m, int k, int expect)
  {
    Assert.Equal(expect, new Solution().MinDays(bloomDay, m, k));
  }
}
