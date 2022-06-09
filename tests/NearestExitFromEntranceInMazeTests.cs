using LeetCode.NearestExitFromEntranceInMaze;

namespace tests;

public class NearestExitFromEntranceInMazeTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new char[][] {
        new char[]{'+', '+', '.', '+'},
        new char[]{'.', '.', '.', '+'},
        new char[]{'+', '+', '+', '.'},
      },
      new int[]{1,2},
      1
    };
    yield return new object[]{
      new char[][] {
        new char[]{'+', '+', '+'},
        new char[]{'.', '.', '.'},
        new char[]{'+', '+', '+'},
      },
      new int[]{1,0},
      2
    };
    yield return new object[]{
      new char[][] {
        new char[]{'.', '+'},
      },
      new int[]{0,0},
      -1
    };

  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(char[][] maze, int[] entrance, int expect)
  {
    int result = new Solution().NearestExit(maze, entrance);
    Assert.Equal(expect, result);
  }
}