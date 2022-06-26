using LeetCode.Triangle;

namespace tests;

public class TriangleTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{2},
        new int[]{3,4},
        new int[]{6,5,7},
        new int[]{4,1,8,3},
      },
      11
    };
    yield return new object[]{
      new int[][]{
        new int[]{-10},
      },
      -10
    };
    yield return new object[]{
      new int[][]{
        new int[]{-1},
        new int[]{2,3},
        new int[]{1,-1,-3},
      },
      -1
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(IList<IList<int>> triangle, int expect)
  {
    Assert.Equal(expect, new Solution().MinimumTotal(triangle));
  }
}