using LeetCode.ShortestPathWithAlternatingColors;

namespace tests;

public class ShortestPathWithAlternatingColorsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      3,
      new int[][]{
        new int[]{0,1},
        new int[]{1,2},
      },
      new int[][]{},
      new int[]{0,1,-1},
    };

    yield return new object[]{
      3,
      new int[][]{
        new int[]{0,1},
      },
      new int[][]{
        new int[]{2,1},
      },
      new int[]{0,1,-1},
    };
    yield return new object[]{
      3,
      new int[][]{
        new int[]{0,1},
      },
      new int[][]{
        new int[]{1,2},
      },
      new int[]{0,1,2},
    };
    yield return new object[]{
      3,
      new int[][]{
        new int[]{0,1},
        new int[]{0,2},
      },
      new int[][]{
        new int[]{1,0},
      },
      new int[]{0,1,1},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] redEdges, int[][] blueEdges, int[] expect)
  {
    var result = new Solution().ShortestAlternatingPaths(n, redEdges, blueEdges);
    Assert.Equal(n, result.Length);
    for (int i = 0; i < n; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}