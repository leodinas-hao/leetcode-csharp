using LeetCode.FindRightInterval;

namespace tests;

public class FindRightIntervalTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2}
      },
      new int[]{-1}
    };

    yield return new object[]{
      new int[][]{
        new int[]{3,4},
        new int[]{2,3},
        new int[]{1,2}
      },
      new int[]{-1,0,1}
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,4},
        new int[]{2,3},
        new int[]{3,4},
      },
      new int[]{-1,2,-1}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] intervals, int[] expect)
  {
    Assert.Equal(expect, new Solution().FindRightInterval(intervals));
  }
}