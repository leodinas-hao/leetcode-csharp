using LeetCode.SumOfMutatedArrayClosestToTarget;

namespace tests;

public class SumOfMutatedArrayClosestToTargetTests
{
  [Theory]
  [InlineData(new int[] { 4, 9, 3 }, 10, 3)]
  [InlineData(new int[] { 2, 3, 5 }, 10, 5)]
  [InlineData(new int[] { 60864, 25176, 27249, 21296, 20204 }, 56803, 11361)]
  public void Test1(int[] arr, int target, int expect)
  {
    Assert.Equal(expect, new Solution().FindBestValue(arr, target));
  }
}
