using LeetCode.MinimumPathSum;

namespace tests;


public class MinimumPathSumTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,3,1},
        new int[]{1,5,1},
        new int[]{4,2,1},
      },
      7
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{4,5,6},
      },
      12
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    Assert.Equal(expect, new Solution().MinPathSum(grid));
  }
}