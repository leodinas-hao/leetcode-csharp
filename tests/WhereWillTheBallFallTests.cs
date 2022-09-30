using LeetCode.WhereWillTheBallFall;

namespace tests;

public class WhereWillTheBallFallTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,1,1,1,1,1},
        new int[]{-1,-1,-1,-1,-1,-1},
        new int[]{1,1,1,1,1,1},
        new int[]{-1,-1,-1,-1,-1,-1},
      },
      new int[]{0,1,2,3,4,-1}
    };

    yield return new object[]{
      new int[][]{
        new int[]{1,1,1,-1,-1},
        new int[]{1,1,1,-1,-1},
        new int[]{-1,-1,-1,1,1},
        new int[]{1,1,1,1,-1},
        new int[]{-1,-1,-1,-1,-1},
      },
      new int[]{1,-1,-1,-1,-1}
    };

    yield return new object[]{
      new int[][]{
        new int[]{-1},
      },
      new int[]{-1}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int[] expect)
  {
    Assert.Equal(expect, new Solution().FindBall(grid));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] grid, int[] expect)
  {
    Assert.Equal(expect, new Solution2().FindBall(grid));
  }
}