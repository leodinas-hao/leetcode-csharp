using LeetCode.NumberOfClosedIslands;

namespace tests;

public class NumberOfClosedIslandsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,1,1,1,1,1,1,0},
        new int[]{1,0,0,0,0,1,1,0},
        new int[]{1,0,1,0,1,1,1,0},
        new int[]{1,0,0,0,0,1,0,1},
        new int[]{1,1,1,1,1,1,1,0},
      },
      2
    };
    yield return new object[]{
      new int[][]{
        new int[]{0,0,1,0,0},
        new int[]{0,1,0,1,0},
        new int[]{0,1,1,1,0},
      },
      1
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,1,1,1,1,1,1},
        new int[]{1,0,0,0,0,0,1},
        new int[]{1,0,1,1,1,0,1},
        new int[]{1,0,1,0,1,0,1},
        new int[]{1,0,1,1,1,0,1},
        new int[]{1,0,0,0,0,0,1},
        new int[]{1,1,1,1,1,1,1},
      },
      2
    };
    yield return new object[]{
      new int[][] {
        new int[] {0,0,1,1,0,1,0,0,1,0},
        new int[] {1,1,0,1,1,0,1,1,1,0},
        new int[] {1,0,1,1,1,0,0,1,1,0},
        new int[] {0,1,1,0,0,0,0,1,0,1},
        new int[] {0,0,0,0,0,0,1,1,1,0},
        new int[] {0,1,0,1,0,1,0,1,1,1},
        new int[] {1,0,1,0,1,1,0,0,0,1},
        new int[] {1,1,1,1,1,1,0,0,0,0},
        new int[] {1,1,1,0,0,1,0,1,0,1},
        new int[] {1,1,1,0,1,1,0,1,1,0},
      },
      5
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int count = new Solution().ClosedIsland(grid);
    Assert.Equal(expect, count);
  }
}
