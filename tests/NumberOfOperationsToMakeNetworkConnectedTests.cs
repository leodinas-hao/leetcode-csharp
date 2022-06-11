using LeetCode.NumberOfOperationsToMakeNetworkConnected;

namespace tests;

public class NumberOfOperationsToMakeNetworkConnectedTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      4,
      new int[][]{
        new int[]{0,1},
        new int[]{0,2},
        new int[]{1,2},
      },
      1
    };
    yield return new object[]{
      6,
      new int[][]{
        new int[]{0,1},
        new int[]{0,2},
        new int[]{0,3},
        new int[]{1,2},
        new int[]{1,3},
      },
      2
    };
    yield return new object[]{
      6,
      new int[][]{
        new int[]{0,1},
        new int[]{0,2},
        new int[]{0,3},
        new int[]{1,2},
      },
      -1
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] connections, int expect)
  {
    var moves = new Solution().MakeConnected(n, connections);
    Assert.Equal(expect, moves);
  }
}