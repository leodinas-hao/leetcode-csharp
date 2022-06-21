using LeetCode.RottingOranges;

namespace tests;

public class RottingOrangesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{2,1,1},
        new int[]{1,1,0},
        new int[]{0,1,1},
      },
      4
    };
    yield return new object[]{
      new int[][]{
        new int[]{2,1,1},
        new int[]{0,1,1},
        new int[]{1,0,1},
      },
      -1
    };
    yield return new object[]{
      new int[][]{
        new int[]{0,2},
      },
      0
    };
    yield return new object[]{
      new int[][]{new int[]{0}},
      0,
    };
    yield return new object[]{
      new int[][]{
        new int[]{2,1,1},
        new int[]{1,1,1},
        new int[]{0,1,2},
      },
      2,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int result = new Solution().OrangesRotting(grid);
    Assert.Equal(expect, result);
  }
}
