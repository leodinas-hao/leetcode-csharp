using LeetCode.FindTheDuplicateNumber;

namespace tests;

public class FindTheDuplicateNumberTests
{
  [Theory]
  [InlineData(new int[] { 1, 3, 4, 2, 2 }, 2)]
  [InlineData(new int[] { 3, 1, 3, 4, 2 }, 3)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().FindDuplicate(nums));
  }
}
