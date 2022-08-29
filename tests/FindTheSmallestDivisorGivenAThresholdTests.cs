using LeetCode.FindTheSmallestDivisorGivenAThreshold;

namespace tests;

public class FindTheSmallestDivisorGivenAThresholdTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 5, 9 }, 6, 5)]
  [InlineData(new int[] { 44, 22, 33, 11, 1 }, 5, 44)]
  public void Test1(int[] nums, int threshold, int expect)
  {
    Assert.Equal(expect, new Solution().SmallestDivisor(nums, threshold));
  }
}
