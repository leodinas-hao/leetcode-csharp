using LeetCode.PlusOne;

namespace tests;

public class PlusOneTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
  [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
  [InlineData(new int[] { 9, 9 }, new int[] { 1, 0, 0 })]
  [InlineData(new int[] { 1, 9, 9 }, new int[] { 2, 0, 0 })]
  public void Test1(int[] digits, int[] expect)
  {
    Assert.Equal(expect, new Solution().PlusOne(digits));
  }
}
