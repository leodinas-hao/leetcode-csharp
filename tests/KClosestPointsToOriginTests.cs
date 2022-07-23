using LeetCode.KClosestPointsToOrigin;

namespace tests;

public class KClosestPointsToOriginTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,3},
        new int[]{-2,2},
      },
      1,
      new int[][]{
        new int[]{-2,2},
      },
    };

    yield return new object[]{
      new int[][]{
        new int[]{3,3},
        new int[]{5,-1},
        new int[]{-2,4},
      },
      2,
      new int[][]{
        new int[]{3,3},
        new int[]{-2,4},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] points, int k, int[][] expect)
  {
    Assert.Equal(expect, new Solution().KClosest(points, k));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] points, int k, int[][] expect)
  {
    Assert.Equal(expect, new Solution2().KClosest(points, k));
  }
}