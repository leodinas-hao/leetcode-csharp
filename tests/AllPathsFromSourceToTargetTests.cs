using LeetCode.AllPathsFromSourceToTarget;

namespace tests;

public class AllPathsFromSourceToTargetTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{1,2},
        new int[]{3},
        new int[]{3},
        new int[]{},
      },
      new int[][] {
        new int[]{0,1,3},
        new int[]{0,2,3},
      }
    };
    yield return new object[]{
      new int[][] {
        new int[]{4,3,1},
        new int[]{3,2,4},
        new int[]{3},
        new int[]{4},
        new int[]{},
      },
      new int[][] {
        new int[]{0,4},
        new int[]{0,3,4},
        new int[]{0,1,3,4},
        new int[]{0,1,2,3,4},
        new int[]{0,1,4},
      }
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] graph, int[][] expect)
  {
    var result = new Solution().AllPathsSourceTarget(graph);
    Assert.Equal(result.Count, expect.Length);
    foreach (var row in expect)
    {
      Assert.Contains(result, r => Enumerable.SequenceEqual(r, row));
    }
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] graph, int[][] expect)
  {
    var result = new Solution2().AllPathsSourceTarget(graph);
    Assert.Equal(result.Count, expect.Length);
    foreach (var row in expect)
    {
      Assert.Contains(result, r => Enumerable.SequenceEqual(r, row));
    }
  }
}
