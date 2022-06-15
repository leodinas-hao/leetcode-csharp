using LeetCode.RotateArray;

namespace tests;

public class RotateArrayTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
  [InlineData(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
  public void Test1(int[] nums, int k, int[] expect)
  {
    new Solution().Rotate(nums, k);
    for (int i = 0; i < nums.Length; i++)
    {
      Assert.Equal(expect[i], nums[i]);
    }
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
  [InlineData(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
  public void Test2(int[] nums, int k, int[] expect)
  {
    new Solution2().Rotate(nums, k);
    for (int i = 0; i < nums.Length; i++)
    {
      Assert.Equal(expect[i], nums[i]);
    }
  }
}