namespace tests;

using LeetCode.TwoSum;

public class TwoSumTests
{
  [Fact]
  public void Test1()
  {
    int[] nums = { 1, 2 };
    var actual = new Solution().TwoSum(nums, 2);
    Assert.Equal(actual.Length, 2);
  }
}
