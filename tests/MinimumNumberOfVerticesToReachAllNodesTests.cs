using LeetCode.MinimumNumberOfVerticesToReachAllNodes;

namespace tests;

public class MinimumNumberOfVerticesToReachAllNodesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      6,
      new int[][]{
        new int[]{0,1},
        new int[]{0,2},
        new int[]{2,5},
        new int[]{3,4},
        new int[]{4,2},
      },
      new int[]{0,3}
    };
    yield return new object[]{
      5,
      new int[][]{
        new int[]{0,1},
        new int[]{2,1},
        new int[]{3,1},
        new int[]{1,4},
        new int[]{2,4},
      },
      new int[]{0,2,3}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, IList<IList<int>> edges, IList<int> expect)
  {
    var result = new Solution().FindSmallestSetOfVertices(n, edges);
    Assert.Equal(expect.Count, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}
