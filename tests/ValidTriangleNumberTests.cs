using LeetCode.ValidTriangleNumber;

namespace tests;

public class ValidTriangleNumberTests
{
  [Theory]
  [InlineData(new int[] { 2, 2, 3, 4 }, 3)]
  [InlineData(new int[] { 4, 2, 3, 4 }, 4)]
  public void Test1(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution().TriangleNumber(nums));
  }

  [Theory]
  [InlineData(new int[] { 2, 2, 3, 4 }, 3)]
  [InlineData(new int[] { 4, 2, 3, 4 }, 4)]
  public void Test2(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution2().TriangleNumber(nums));
  }

  [Theory]
  [InlineData(new int[] { 2, 2, 3, 4 }, 3)]
  [InlineData(new int[] { 4, 2, 3, 4 }, 4)]
  public void Test3(int[] nums, int expect)
  {
    Assert.Equal(expect, new Solution3().TriangleNumber(nums));
  }
}