using LeetCode.LastStoneWeight;

namespace tests;

public class LastStoneWeightTests
{
  [Theory]
  [InlineData(new int[] { 2, 7, 4, 1, 8, 1 }, 1)]
  [InlineData(new int[] { 1 }, 1)]
  [InlineData(new int[] { 2, 2 }, 0)]
  public void Test1(int[] stones, int expect)
  {
    Assert.Equal(expect, new Solution().LastStoneWeight(stones));
  }
}