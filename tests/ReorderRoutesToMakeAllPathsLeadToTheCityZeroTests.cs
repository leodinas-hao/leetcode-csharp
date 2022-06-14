using LeetCode.ReorderRoutesToMakeAllPathsLeadToTheCityZero;

namespace tests;

public class ReorderRoutesToMakeAllPathsLeadToTheCityZeroTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      6,
      new int[][]{
        new int[]{0,1},
        new int[]{1,3},
        new int[]{2,3},
        new int[]{4,0},
        new int[]{4,5},
      },
      3,
    };

    yield return new object[]{
      5,
      new int[][]{
        new int[]{1,0},
        new int[]{1,2},
        new int[]{3,2},
        new int[]{3,4},
      },
      2,
    };

    yield return new object[]{
      3,
      new int[][]{
        new int[]{1,0},
        new int[]{2,0}
      },
      0,
    };

    yield return new object[]{
      4,
      new int[][]{
        new int[]{0,1},
        new int[]{2,0},
        new int[]{3,2},
      },
      1,
    };
    yield return new object[]{
      5,
      new int[][]{
        new int[]{1,0},
        new int[]{1,2},
        new int[]{2,3},
        new int[]{4,2},
      },
      2,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] connections, int expect)
  {
    var result = new Solution().MinReorder(n, connections);
    Assert.Equal(expect, result);
  }
}
