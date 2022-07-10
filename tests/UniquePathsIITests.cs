using LeetCode.UniquePathsII;

namespace tests;

public class UniquePathsIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{0,0,0},
      },
      2,
    };
    yield return new object[]{
      new int[][]{
        new int[]{0,1},
        new int[]{0,0},
      },
      1,
    };
    yield return new object[]{
      new int[][]{
        new int[]{0,0},
      },
      1,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    Assert.Equal(expect, new Solution().UniquePathsWithObstacles(grid));
  }
}