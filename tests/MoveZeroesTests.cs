using LeetCode.MoveZeroes;

namespace tests;

public class MoveZeroesTests
{
  [Theory]
  [InlineData(new int[] { 0, 1, 0, 3, 12 }, 2)]
  [InlineData(new int[] { 0 }, 1)]
  public void Test1(int[] nums, int k)
  {
    new Solution().MoveZeroes(nums);
    int len = nums.Length;
    for (int i = 0; i < k; i++)
    {
      Assert.Equal(0, nums[len - i - 1]);
    }
  }
}