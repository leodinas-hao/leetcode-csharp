using LeetCode.FindKClosestElements;

namespace tests;

public class FindKClosestElementsTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 3, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, -1, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 2, 3, 4, 5 })]
  public void Test1(int[] arr, int k, int x, int[] expect)
  {
    var result = new Solution().FindClosestElements(arr, k, x);
    Assert.Equal(expect.Length, result.Count);
    for (int i = 0; i < expect.Length; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 3, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, -1, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 2, 3, 4, 5 })]
  public void Test2(int[] arr, int k, int x, int[] expect)
  {
    var result = new Solution2().FindClosestElements(arr, k, x);
    Assert.Equal(expect.Length, result.Count);
    for (int i = 0; i < expect.Length; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}
