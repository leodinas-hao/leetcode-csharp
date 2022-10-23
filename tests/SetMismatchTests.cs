using LeetCode.SetMismatch;

namespace tests;

public class SetMismatchTests
{

  [Theory]
  [InlineData(new int[] { 1, 2, 2, 4 }, new int[] { 2, 3 })]
  [InlineData(new int[] { 1, 1 }, new int[] { 1, 2 })]
  [InlineData(new int[] { 3, 2, 3, 4, 6, 5 }, new int[] { 3, 1 })]
  public void Test1(int[] nums, int[] expect)
  {
    var result = new Solution().FindErrorNums(nums);
    Assert.Equal(expect, result);
  }
}
