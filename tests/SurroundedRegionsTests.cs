using LeetCode.SurroundedRegions;

namespace tests;

public class SurroundedRegionsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new char[][]{
        new char[]{'X','X','X','X'},
        new char[]{'X','O','O','X'},
        new char[]{'X','X','O','X'},
        new char[]{'X','O','X','X'},
      },
      new char[][]{
        new char[]{'X','X','X','X'},
        new char[]{'X','X','X','X'},
        new char[]{'X','X','X','X'},
        new char[]{'X','O','X','X'},
      },
    };
    yield return new object[]{
      new char[][]{
        new char[]{'X'},
      },
      new char[][]{
        new char[]{'X'},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(char[][] board, char[][] expect)
  {
    new Solution().Solve(board);
    Assert.Equal(expect, board);
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(char[][] board, char[][] expect)
  {
    new Solution2().Solve(board);
    Assert.Equal(expect, board);
  }
}