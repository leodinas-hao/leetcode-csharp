using LeetCode.JumpGameIII;

namespace tests;

public class JumpGameIIITests
{
  [Theory]
  [InlineData(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 5, true)]
  [InlineData(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 0, true)]
  [InlineData(new int[] { 3, 0, 2, 1, 2 }, 2, false)]
  public void Test1(int[] arr, int start, bool expect)
  {
    Assert.Equal(expect, new Solution().CanReach(arr, start));
  }
}
