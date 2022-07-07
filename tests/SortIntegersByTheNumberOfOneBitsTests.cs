using LeetCode.SortIntegersByTheNumberOfOneBits;

namespace tests;

public class SortIntegersByTheNumberOfOneBitsTests
{
  [Theory]
  [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 0, 1, 2, 4, 8, 3, 5, 6, 7 })]
  [InlineData(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 })]
  public void Test1(int[] arr, int[] expect)
  {
    Assert.Equal(expect, new Solution().SortByBits(arr));
  }
}