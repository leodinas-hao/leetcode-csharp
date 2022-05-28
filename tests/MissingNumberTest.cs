using LeetCode.MissingNumber;

namespace tests;

public class MissingNumberTests
{
  [Theory]
  [InlineData(new int[] { 3, 0, 1 }, 2)]
  [InlineData(new int[] { 0, 1 }, 2)]
  [InlineData(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
  public void Test1(int[] nums, int expect)
  {
    var actual = new Solution().MissingNumber(nums);
    Assert.Equal(actual, expect);
  }
}