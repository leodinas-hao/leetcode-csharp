using LeetCode.MaxAreaOfIsland;

namespace tests;

public class MaxAreaOfIslandTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new int[][]{
        new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
        new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
        new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
        new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
        new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
        new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
        new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
        new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
      },
      6
    };
    yield return new object[] {
      new int[][]{new int[] {0,0,0,0,0,0,0,0}},
      0
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int max = new Solution().MaxAreaOfIsland(grid);
    Assert.Equal(expect, max);
  }
}
