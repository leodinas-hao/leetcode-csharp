using LeetCode.JumpGame;

namespace tests;

public class JumpGameTests
{
  [Theory]
  [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
  [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
  public void Test1(int[] nums, bool expect)
  {
    Assert.Equal(expect, new Solution().CanJump(nums));
  }
}