using LeetCode.CheckIfNAndItsDoubleExist;

namespace tests;

public class CheckIfNAndItsDoubleExistTests
{
  [Theory]
  [InlineData(new int[] { 10, 2, 5, 3 }, true)]
  [InlineData(new int[] { 7, 1, 14, 11 }, true)]
  [InlineData(new int[] { 3, 1, 7, 11 }, false)]
  [InlineData(new int[] { -10, 12, -20, -8, 15 }, true)]
  [InlineData(new int[] { 0, 0 }, true)]
  public void Test1(int[] arr, bool expect)
  {
    var result = new Solution().CheckIfExist(arr);
    Assert.Equal(expect, result);
  }
}