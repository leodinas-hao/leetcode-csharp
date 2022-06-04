using LeetCode.KDiffPairsInAnArray;

namespace tests;

public class KDiffPairsInAnArrayTests
{
  [Theory]
  [InlineData(new int[] { 3, 1, 4, 1, 5 }, 2, 2)]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 4)]
  [InlineData(new int[] { 1, 3, 1, 5, 4 }, 0, 1)]
  public void Test1(int[] nums, int k, int expect)
  {
    var result = new Solution().FindPairs(nums, k);
    Assert.Equal(expect, result);
  }
}
