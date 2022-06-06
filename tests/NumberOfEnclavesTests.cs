using LeetCode.NumberOfEnclaves;

namespace tests;

public class NumberOfEnclavesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{0,0,0,0},
        new int[]{1,0,1,0},
        new int[]{0,1,1,0},
        new int[]{0,0,0,0},
      },
      3
    };
    yield return new object[]{
      new int[][] {
        new int[]{0,1,1,0},
        new int[]{0,0,1,0},
        new int[]{0,0,1,0},
        new int[]{0,0,0,0},
      },
      0
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int num = new Solution().NumEnclaves(grid);
    Assert.Equal(expect, num);
  }
}
