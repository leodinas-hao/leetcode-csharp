using LeetCode.IntervalListIntersections;

namespace tests;

public class IntervalListIntersectionsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{0,2},
        new int[]{5,10},
        new int[]{13,23},
        new int[]{24,25},
      },
      new int[][]{
        new int[]{1,5},
        new int[]{8,12},
        new int[]{15,24},
        new int[]{25,26},
      },
      new int[][]{
        new int[]{1,2},
        new int[]{5,5},
        new int[]{8,10},
        new int[]{15,23},
        new int[]{24,24},
        new int[]{25,25},
      },
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,3},
        new int[]{5,9},
      },
      new int[][]{},
      new int[][]{},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] l1, int[][] l2, int[][] expect)
  {
    var result = new Solution().IntervalIntersection(l1, l2);
    Assert.Equal(expect, result);
  }
}