using LeetCode.PartitionEqualSubsetSum;

namespace tests;

public class PartitionEqualSubsetSumTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 5 }, false)]
  [InlineData(new int[] { 1, 5, 11, 5 }, true)]
  public void Test1(int[] nums, bool expect)
  {
    Assert.Equal(expect, new Solution().CanPartition(nums));
  }
}
