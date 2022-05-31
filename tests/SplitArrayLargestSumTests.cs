using LeetCode.SplitArrayLargestSum;

namespace tests;

public class SplitArrayLargestSumTests
{
  [Theory]
  [InlineData(new int[] { 7, 2, 5, 10, 8 }, 2, 18)]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, 9)]
  [InlineData(new int[] { 1, 4, 4 }, 3, 4)]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 15)]
  public void Test1(int[] nums, int m, int except)
  {
    int result = new Solution().SplitArray(nums, m);
    Assert.Equal(except, result);
  }
}
