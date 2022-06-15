using LeetCode.ShortestPathVisitingAllNodes;

namespace tests;

public class ShortestPathVisitingAllNodesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{0},
        new int[]{0},
        new int[]{0},
      },
      4
    };
    yield return new object[]{
      new int[][]{
        new int[]{1},
        new int[]{0,2,4},
        new int[]{1,3,4},
        new int[]{2},
        new int[]{1,2},
      },
      4
    };
    yield return new object[]{
      new int[][]{
        new int[]{1},
        new int[]{0},
      },
      1
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] graph, int expect)
  {
    var result = new Solution().ShortestPathLength(graph);
    Assert.Equal(expect, result);
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] graph, int expect)
  {
    var result = new Solution2().ShortestPathLength(graph);
    Assert.Equal(expect, result);
  }
}