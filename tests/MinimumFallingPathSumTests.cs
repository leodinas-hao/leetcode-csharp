using LeetCode.MinimumFallingPathSum;

namespace tests;

public class MinimumFallingPathSumTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{2,1,3},
        new int[]{6,5,4},
        new int[]{7,8,9},
      },
      13
    };
    yield return new object[]{
      new int[][]{
        new int[]{-19, 57},
        new int[]{-40, -5},
      },
      -59
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] matrix, int expect)
  {
    Assert.Equal(expect, new Solution().MinFallingPathSum(matrix));
  }
}