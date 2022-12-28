using LeetCode.RemoveStonesToMinimizeTheTotal;

namespace tests;

public class RemoveStonesToMinimizeTheTotalTests
{
  [Theory]
  [InlineData(new int[] { 4, 3, 6, 7 }, 3, 12)]
  [InlineData(new int[] { 5, 4, 9 }, 2, 12)]
  public void Test1(int[] piles, int k, int expect)
  {
    Assert.Equal(expect, new Solution().MinStoneSum(piles, k));
  }
}
