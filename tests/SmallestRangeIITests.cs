using LeetCode.SmallestRangeII;

namespace tests;

public class SmallestRangeIITests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 6 }, 3, 3)]
  [InlineData(new int[] { 0, 10 }, 2, 6)]
  [InlineData(new int[] { 1 }, 0, 0)]
  public void Test1(int[] nums, int k, int expect)
  {
    Assert.Equal(expect, new Solution().SmallestRangeII(nums, k));
  }
}