using LeetCode.KokoEatingBananas;

namespace tests;

public class KokoEatingBananasTests
{
  [Theory]
  [InlineData(new int[] { 30, 11, 23, 4, 20 }, 6, 23)]
  [InlineData(new int[] { 30, 11, 23, 4, 20 }, 5, 30)]
  [InlineData(new int[] { 3, 6, 7, 11 }, 8, 4)]
  public void Test1(int[] piles, int h, int expect)
  {
    Assert.Equal(expect, new Solution().MinEatingSpeed(piles, h));
  }
}
