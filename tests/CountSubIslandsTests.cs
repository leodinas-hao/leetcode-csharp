using LeetCode.CountSubIslands;

namespace tests;

public class CountSubIslandsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{1,1,1,0,0},
        new int[]{0,1,1,1,1},
        new int[]{0,0,0,0,0},
        new int[]{1,0,0,0,0},
        new int[]{1,1,0,1,1},
      },
      new int[][] {
        new int[]{1,1,1,0,0},
        new int[]{0,0,1,1,1},
        new int[]{0,1,0,0,0},
        new int[]{1,0,1,1,0},
        new int[]{0,1,0,1,0},
      },
      3,
    };
    yield return new object[]{
      new int[][] {
        new int[]{1,0,1,0,1},
        new int[]{1,1,1,1,1},
        new int[]{0,0,0,0,0},
        new int[]{1,1,1,1,1},
        new int[]{1,0,1,0,1},
      },
      new int[][] {
        new int[]{0,0,0,0,0},
        new int[]{1,1,1,1,1},
        new int[]{0,1,0,1,0},
        new int[]{0,1,0,1,0},
        new int[]{1,0,0,0,1},
      },
      2,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid1, int[][] grid2, int expect)
  {
    var result = new Solution().CountSubIslands(grid1, grid2);
    Assert.Equal(expect, result);
  }
}
