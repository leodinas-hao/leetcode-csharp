using LeetCode.NumberOfIslands;

namespace tests;

public class NumberOfIslandsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new char[][] {
        new char[] {'1','1','1','1','0'},
        new char[] {'1','1','0','1','0'},
        new char[] {'1','1','0','0','0'},
        new char[] {'0','0','0','0','0'},
      },
      1
    };
    yield return new object[]{
      new char[][] {
        new char[] {'1','1','0','0','0'},
        new char[] {'1','1','0','0','0'},
        new char[] {'0','0','1','0','0'},
        new char[] {'0','0','0','1','1'},
      },
      3
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(char[][] grid, int expect)
  {
    var count = new Solution().NumIslands(grid);
    Assert.Equal(expect, count);
  }
}
