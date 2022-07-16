using LeetCode.CombinationSumIV;

namespace tests;

public class CombinationSumIVTests
{
  [Theory]
  [InlineData(new int[] { 9 }, 3, 0)]
  [InlineData(new int[] { 1, 2, 3 }, 4, 7)]
  public void Test1(int[] nums, int target, int expect)
  {
    Assert.Equal(expect, new Solution().CombinationSum4(nums, target));
  }
}