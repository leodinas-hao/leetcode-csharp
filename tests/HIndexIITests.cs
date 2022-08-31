using LeetCode.HIndexII;

namespace tests;

public class HIndexIITests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 100 }, 2)]
  [InlineData(new int[] { 0, 1, 3, 5, 6 }, 3)]
  public void Test1(int[] citations, int expect)
  {
    Assert.Equal(expect, new Solution().HIndex(citations));
  }
}
