using LeetCode.ShortestSubarrayToBeRemovedToMakeArraySorted;

namespace tests;

public class ShortestSubarrayToBeRemovedToMakeArraySortedTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, 0)]
  [InlineData(new int[] { 5, 4, 3, 2, 1 }, 4)]
  [InlineData(new int[] { 1, 2, 3, 10, 4, 2, 3, 5 }, 3)]
  public void Test1(int[] arr, int expect)
  {
    Assert.Equal(expect, new Solution().FindLengthOfShortestSubarray(arr));
  }
}
