using LeetCode.FindLatestGroupOfSizeM;

namespace tests;

public class FindLatestGroupOfSizeMTests
{
  [Theory]
  [InlineData(new int[] { 3, 5, 1, 2, 4 }, 1, 4)]
  [InlineData(new int[] { 3, 1, 5, 4, 2 }, 2, -1)]
  [InlineData(new int[] { 1, 2 }, 1, 1)]
  public void Test0(int[] arr, int m, int expect)
  {
    Assert.Equal(expect, new Solution0().FindLatestStep(arr, m));
  }

  [Theory]
  [InlineData(new int[] { 3, 5, 1, 2, 4 }, 1, 4)]
  [InlineData(new int[] { 3, 1, 5, 4, 2 }, 2, -1)]
  [InlineData(new int[] { 1, 2 }, 1, 1)]
  public void Test(int[] arr, int m, int expect)
  {
    Assert.Equal(expect, new Solution().FindLatestStep(arr, m));
  }

  [Theory]
  [InlineData(new int[] { 3, 5, 1, 2, 4 }, 1, 4)]
  [InlineData(new int[] { 3, 1, 5, 4, 2 }, 2, -1)]
  [InlineData(new int[] { 1, 2 }, 1, 1)]
  public void Test1(int[] arr, int m, int expect)
  {
    Assert.Equal(expect, new Solution1().FindLatestStep(arr, m));
  }

  [Theory]
  [InlineData(new int[] { 3, 5, 1, 2, 4 }, 1, 4)]
  [InlineData(new int[] { 3, 1, 5, 4, 2 }, 2, -1)]
  [InlineData(new int[] { 1, 2 }, 1, 1)]
  public void Test2(int[] arr, int m, int expect)
  {
    Assert.Equal(expect, new Solution2().FindLatestStep(arr, m));
  }
}
