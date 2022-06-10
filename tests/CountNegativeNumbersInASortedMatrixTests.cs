using LeetCode.CountNegativeNumbersInASortedMatrix;

namespace tests;

public class CountNegativeNumbersInASortedMatrixTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{4,3,2,-1},
        new int[]{3,2,1,-1},
        new int[]{1,1,-1,-2},
        new int[]{-1,-1,-2,-3},
      },
      8
    };
    yield return new object[]{
      new int[][] {
        new int[]{3,2},
        new int[]{1,0},
      },
      0
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] grid, int expect)
  {
    int result = new Solution().CountNegatives(grid);
    Assert.Equal(expect, result);
  }
}
