using LeetCode.MaxPointsOnALine;

namespace tests;

public class MaxPointsOnALineTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,1},
        new int[]{2,2},
        new int[]{3,3},
      },
      3,
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,1},
        new int[]{3,2},
        new int[]{5,3},
        new int[]{4,1},
        new int[]{2,3},
        new int[]{1,4},
      },
      4,
    };
    yield return new object[]{
      new int[][]{
        new int[]{2,3},
        new int[]{3,3},
        new int[]{-5,3},
      },
      3,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] points, int expect)
  {
    Assert.Equal(expect, new Solution().MaxPoints(points));
  }
}
