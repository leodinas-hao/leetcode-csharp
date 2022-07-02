using LeetCode.SumOfAllOddLengthSubarray;

namespace tests;

public class SumOfAllOddLengthSubarrayTests
{
  [Theory]
  [InlineData(new int[] { 1, 4, 2, 5, 3 }, 58)]
  [InlineData(new int[] { 1, 2 }, 3)]
  [InlineData(new int[] { 10, 11, 12 }, 66)]
  public void Test1(int[] arr, int expect)
  {
    Assert.Equal(expect, new Solution().SumOddLengthSubarrays(arr));
  }
}