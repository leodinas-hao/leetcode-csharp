using LeetCode.TwoSum;

namespace tests;

public class TwoSumTests
{
  [Theory]
  [InlineData(new int[] { 2, 7, 11, 15 }, 9)]
  [InlineData(new int[] { 3, 2, 4 }, 6)]
  [InlineData(new int[] { 3, 3 }, 6)]
  [InlineData(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11)]
  public void Test1(int[] nums, int target)
  {
    var actual = new Solution().TwoSum(nums, target);
    Assert.Equal(2, actual.Length);
    Assert.Equal(target, nums[actual[0]] + nums[actual[1]]);
  }
}
