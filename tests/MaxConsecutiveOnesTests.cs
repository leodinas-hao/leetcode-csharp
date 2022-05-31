using LeetCode.MaxConsecutiveOnes;

namespace tests;

public class MaxConsecutiveOnesTests
{
  [Theory]
  [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
  [InlineData(new int[] { 1, 0, 1, 1, 0, 1 }, 2)]
  public void Test1(int[] nums, int expect)
  {
    int max = new Solution().FindMaxConsecutiveOnes(nums);
    Assert.Equal(expect, max);
  }
}