using LeetCode.JumpGameII;

namespace tests;

public class JumpGameIITests
{
  [Theory]
  [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
  [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
  [InlineData(new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0 }, 3)]
  public void Test(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().Jump(nums));
  }

  [Theory]
  [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
  [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
  [InlineData(new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0 }, 3)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().Jump(nums));
  }

  [Theory]
  [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
  [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
  [InlineData(new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0 }, 3)]
  public void Test3(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution3().Jump(nums));
  }
}
