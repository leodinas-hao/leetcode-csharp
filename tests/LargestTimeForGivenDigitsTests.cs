using LeetCode.LargestTimeForGivenDigits;

namespace tests;

public class LargestTimeForGivenDigitsTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, "23:41")]
  [InlineData(new int[] { 5, 5, 5, 5 }, "")]
  public void Test1(int[] arr, string expect)
  {
    var sol = new Solution();
    var result = sol.LargestTimeFromDigits(arr);
    Assert.Equal(result, expect);
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, "23:41")]
  [InlineData(new int[] { 5, 5, 5, 5 }, "")]
  public void Test2(int[] arr, string expect)
  {
    var sol = new Solution2();
    var result = sol.LargestTimeFromDigits(arr);
    Assert.Equal(result, expect);
  }
}