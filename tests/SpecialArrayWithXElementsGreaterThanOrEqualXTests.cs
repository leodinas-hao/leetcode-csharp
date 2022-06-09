using LeetCode.SpecialArrayWithXElementsGreaterThanOrEqualX;

namespace tests;

public class SpecialArrayWithXElementsGreaterThanOrEqualXTests
{
  [Theory]
  [InlineData(new int[] { 3, 5 }, 2)]
  [InlineData(new int[] { 0, 0 }, -1)]
  [InlineData(new int[] { 0, 4, 3, 0, 4 }, 3)]
  public void Test1(int[] nums, int expect)
  {
    int result = new Solution().SpecialArray(nums);
    Assert.Equal(expect, result);
  }
}
