using LeetCode.FindEventualSafeStates;

namespace tests;

public class FindEventualSafeStatesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2},
        new int[]{2,3},
        new int[]{5},
        new int[]{0},
        new int[]{5},
        new int[]{},
        new int[]{},
      },
      new int[]{2,4,5,6}
    };

    yield return new object[]{
      new int[][]{
        new int[]{1,2,3,4},
        new int[]{1,2},
        new int[]{3,4},
        new int[]{0,4},
        new int[]{},
      },
      new int[]{4}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] graph, int[] expect)
  {
    var result = new Solution().EventualSafeNodes(graph);
    Assert.Equal(result.Count, expect.Length);
    for (int i = 0; i < result.Count; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}
