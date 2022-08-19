using LeetCode.NumberOfLongestIncreasingSubsequence;

namespace tests;

public class NumberOfLongestIncreasingSubsequenceTests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 5, 4, 7 }, 2)]
  [InlineData(new int[] { 2, 2, 2, 2, 2 }, 5)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().FindNumberOfLIS(nums));
  }
}