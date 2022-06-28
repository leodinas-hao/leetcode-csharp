using LeetCode.DeleteAndEarn;

namespace tests;

public class DeleteAndEarnTests
{
  [Theory]
  [InlineData(new int[] { 3, 4, 2 }, 6)]
  [InlineData(new int[] { 2, 2, 3, 3, 3, 4 }, 9)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().DeleteAndEarn(nums));
  }

  [Theory]
  [InlineData(new int[] { 3, 4, 2 }, 6)]
  [InlineData(new int[] { 2, 2, 3, 3, 3, 4 }, 9)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().DeleteAndEarn(nums));
  }
}
