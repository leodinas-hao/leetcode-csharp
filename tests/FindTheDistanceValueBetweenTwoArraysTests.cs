using LeetCode.FindTheDistanceValueBetweenTwoArrays;

namespace tests;

public class FindTheDistanceValueBetweenTwoArraysTests
{
  [Theory]
  [InlineData(new int[] { 4, 5, 8 }, new int[] { 10, 9, 1, 8 }, 2, 2)]
  [InlineData(new int[] { 1, 4, 2, 3 }, new int[] { -4, -3, 6, 10, 20, 30 }, 3, 2)]
  [InlineData(new int[] { 2, 1, 100, 3 }, new int[] { -5, -2, 10, -3, 7 }, 6, 1)]
  public void Test1(int[] arr1, int[] arr2, int d, int expect)
  {
    var result = new Solution().FindTheDistanceValue(arr1, arr2, d);
    Assert.Equal(expect, result);
  }
}
