using LeetCode.MaximalSquare;

namespace tests;

public class MaximalSquareTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new char[][]{
        new char[]{'1','0','1','0','0'},
        new char[]{'1','0','1','1','1'},
        new char[]{'1','1','1','1','1'},
        new char[]{'1','0','0','1','0'},
      },
      4,
    };
    yield return new object[]{
      new char[][]{
        new char[]{'0','1'},
        new char[]{'1','0'},
      },
      1,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(char[][] matrix, int expect)
  {
    Assert.Equal(expect, new Solution().MaximalSquare(matrix));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(char[][] matrix, int expect)
  {
    Assert.Equal(expect, new Solution2().MaximalSquare(matrix));
  }
}