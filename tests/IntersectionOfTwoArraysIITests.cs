using LeetCode.IntersectionOfTwoArraysII;

namespace tests;

public class IntersectionOfTwoArraysIITests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
  [InlineData(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 })]
  [InlineData(new int[] { 1, 2 }, new int[] { 1, 1 }, new int[] { 1 })]
  public void Test1(int[] nums1, int[] nums2, int[] expect)
  {
    var intersection = new Solution().Intersect(nums1, nums2);
    Assert.Equal(expect.Length, intersection.Length);
    foreach (var i in intersection)
    {
      Assert.Contains(i, expect);
    }
  }
}