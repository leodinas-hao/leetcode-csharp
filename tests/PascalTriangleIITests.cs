using LeetCode.PascalTriangleII;

namespace tests;

public class PascalTriangleIITests
{
  [Theory]
  [InlineData(1, new int[] { 1, 1 })]
  [InlineData(0, new int[] { 1 })]
  [InlineData(3, new int[] { 1, 3, 3, 1 })]
  public void Test1(int i, int[] expect)
  {
    Assert.Equal(expect, new Solution().GetRow(i));
  }
}
