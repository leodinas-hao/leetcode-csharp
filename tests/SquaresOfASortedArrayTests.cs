using LeetCode.SquaresOfASortedArray;

namespace tests;

public class SquaresOfASortedArrayTests
{
  [Theory]
  [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
  [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
  public void Test2(int[] nums, int[] expect)
  {
    var result = new Solution2().SortedSquares(nums);
    Assert.Equal(expect.Length, result.Length);
    for (int i = 0; i < result.Length; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }

  [Theory]
  [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
  [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
  public void Test1(int[] nums, int[] expect)
  {
    var result = new Solution().SortedSquares(nums);
    Assert.Equal(expect.Length, result.Length);
    for (int i = 0; i < result.Length; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}
