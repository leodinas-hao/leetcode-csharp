using LeetCode.ShortestBridge;

namespace tests;

public class ShortestBridgeTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{0,1},
        new int[]{1,0},
      },
      1
    };
    yield return new object[]{
      new int[][] {
        new int[]{0,1,0},
        new int[]{0,0,0},
        new int[]{0,0,1},
      },
      2
    };
    yield return new object[]{
      new int[][] {
        new int[]{1,1,1,1,1},
        new int[]{1,0,0,0,1},
        new int[]{1,0,1,0,1},
        new int[]{1,0,0,0,1},
        new int[]{1,1,1,1,1},
      },
      1
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int result = new Solution().ShortestBridge(grid);
    Assert.Equal(expect, result);
  }
}
