using LeetCode.AsFarFromLandAsPossible;

namespace tests;

public class AsFarFromLandAsPossibleTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new int[][] { new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 1 } },
      2
    };
    yield return new object[] {
      new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } },
      4
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    var max = new Solution().MaxDistance(grid);
    Assert.Equal(expect, max);
  }
}
