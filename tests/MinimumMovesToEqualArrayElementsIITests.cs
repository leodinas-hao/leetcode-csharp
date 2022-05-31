using LeetCode.MinimumMovesToEqualArrayElementsII;

namespace tests;

public class MinimumMovesToEqualArrayElementsIITests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, 2)]
  [InlineData(new int[] { 1, 10, 2, 9 }, 16)]
  [InlineData(new int[] { 1, 0, 0, 8, 6 }, 14)]
  public void Test1(int[] nums, int expect)
  {
    var sol = new Solution();
    Assert.Equal(expect, sol.MinMoves2(nums));
  }
}
