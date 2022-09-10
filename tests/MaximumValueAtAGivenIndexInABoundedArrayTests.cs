using LeetCode.MaximumValueAtAGivenIndexInABoundedArray;

namespace tests;

public class MaximumValueAtAGivenIndexInABoundedArrayTests
{
  [Theory]
  [InlineData(6, 1, 10, 3)]
  [InlineData(4, 2, 6, 2)]
  public void Test1(int n, int index, int maxSum, int expect)
  {
    Assert.Equal(expect, new Solution().MaxValue(n, index, maxSum));
  }
}
