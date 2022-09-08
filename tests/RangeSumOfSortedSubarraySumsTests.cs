using LeetCode.RangeSumOfSortedSubarraySums;

namespace tests;

public class RangeSumOfSortedSubarraySumsTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, 4, 1, 5, 13)]
  [InlineData(new int[] { 1, 2, 3, 4 }, 4, 3, 4, 6)]
  [InlineData(new int[] { 1, 2, 3, 4 }, 4, 1, 10, 50)]
  public void Test1(int[] sum, int n, int left, int right, int expect)
  {
    Assert.Equal(expect, new Solution().RangeSum(sum, n, left, right));
  }
}
