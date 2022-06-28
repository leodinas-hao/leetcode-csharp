using LeetCode.MaximalNetworkRank;

namespace tests;

public class MaximalNetworkRankTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      4,
      new int[][]{
        new int[]{0,1},
        new int[]{0,3},
        new int[]{1,2},
        new int[]{1,3},
      },
      4
    };
    yield return new object[]{
      5,
      new int[][]{
        new int[]{0,1},
        new int[]{0,3},
        new int[]{1,2},
        new int[]{1,3},
        new int[]{2,3},
        new int[]{2,4},
      },
      5
    };
    yield return new object[]{
      8,
      new int[][]{
        new int[]{0,1},
        new int[]{1,2},
        new int[]{2,3},
        new int[]{2,4},
        new int[]{5,6},
        new int[]{5,7},
      },
      5
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] roads, int expect)
  {
    Assert.Equal(expect, new Solution().MaximalNetworkRank(n, roads));
  }
}