using LeetCode.RemoveStonesToMinimizeTheTotal;

namespace tests;

public class RemoveStonesToMinimizeTheTotalTests
{
  [Theory]
  [InlineData(new int[] { 4, 3, 6, 7 }, 3, 12)]
  [InlineData(new int[] { 5, 4, 9 }, 2, 12)]
  [InlineData(new int[] { 4122, 9928, 3477, 9942 }, 6, 8768)]
  public void Test1(int[] piles, int k, int expect)
  {
    Assert.Equal(expect, new Solution().MinStoneSum(piles, k));
  }

  [Theory]
  [InlineData(new int[] { 4, 3, 6, 7 }, 3, 12)]
  [InlineData(new int[] { 5, 4, 9 }, 2, 12)]
  [InlineData(new int[] { 4122, 9928, 3477, 9942 }, 6, 8768)]
  public void Test2(int[] piles, int k, int expect)
  {
    Assert.Equal(expect, new Solution2().MinStoneSum(piles, k));
  }
}
