using LeetCode.SubarraySumsDivisibleByK;

namespace tests;

public class SubarraySumsDivisibleByKTests
{
  [Theory]
  [InlineData(new int[] { 4, 5, 0, -2, -3, 1 }, 5, 7)]
  [InlineData(new int[] { 5 }, 9, 0)]
  [InlineData(new int[] { -1, 2, 9 }, 2, 2)]
  public void Test1(int[] nums, int k, int expect)
  {
    var result = new Solution().SubarraysDivByK(nums, k);
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(new int[] { 4, 5, 0, -2, -3, 1 }, 5, 7)]
  [InlineData(new int[] { 5 }, 9, 0)]
  [InlineData(new int[] { -1, 2, 9 }, 2, 2)]
  public void Test2(int[] nums, int k, int expect)
  {
    var result = new Solution2().SubarraysDivByK(nums, k);
    Assert.Equal(expect, result);
  }
}
