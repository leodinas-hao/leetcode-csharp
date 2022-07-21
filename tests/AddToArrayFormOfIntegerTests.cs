using LeetCode.AddToArrayFormOfInteger;

namespace tests;

public class AddToArrayFormOfIntegerTests
{
  [Theory]
  [InlineData(new int[] { 2, 1, 5 }, 806, new int[] { 1, 0, 2, 1 })]
  [InlineData(new int[] { 1, 2, 0, 0 }, 34, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { 2, 7, 4 }, 181, new int[] { 4, 5, 5 })]
  public void Test1(int[] num, int k, IList<int> expect)
  {
    var result = new Solution().AddToArrayForm(num, k);
    Assert.Equal(expect, result.ToArray());
  }
}
