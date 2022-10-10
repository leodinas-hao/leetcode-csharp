using LeetCode.BusRoutes;

namespace tests;

public class BusRoutesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,7},
        new int[]{3,6,7},
      },
      1,
      6,
      2
    };
    yield return new object[]{
      new int[][]{
        new int[]{7,12},
        new int[]{4,5,15},
        new int[]{6},
        new int[]{15,19},
        new int[]{9,12,13},
      },
      15,
      12,
      -1
    };
  }


  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] routes, int source, int target, int expect)
  {
    Assert.Equal(expect, new Solution().NumBusesToDestination(routes, source, target));
  }
}
