using LeetCode.SingleElementInASortedArray;

namespace tests;

public class SingleElementInASortedArrayTests
{
  [Theory]
  [InlineData(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2)]
  [InlineData(new int[] { 3, 3, 7, 7, 10, 11, 11 }, 10)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().SingleNonDuplicate(nums));
  }

  [Theory]
  [InlineData(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2)]
  [InlineData(new int[] { 3, 3, 7, 7, 10, 11, 11 }, 10)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().SingleNonDuplicate(nums));
  }
}
