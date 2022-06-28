using LeetCode.IsGraphBipartite;

namespace tests;

public class IsGraphBipartiteTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{0,2},
        new int[]{0,1,3},
        new int[]{0,2},
      },
      false,
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,3},
        new int[]{0,2},
        new int[]{1,3},
        new int[]{0,2},
      },
      true,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] graph, bool expect)
  {
    Assert.Equal(expect, new Solution().IsBipartite(graph));
  }
}
