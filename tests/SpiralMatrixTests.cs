using LeetCode.SpiralMatrix;

namespace tests;

public class SpiralMatrixTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{4,5,6},
        new int[]{7,8,9},
      },
      new int[]{1,2,3,6,9,8,7,4,5},
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3,4},
        new int[]{5,6,7,8},
        new int[]{9,10,11,12},
      },
      new int[]{1,2,3,4,8,12,11,10,9,5,6,7},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] matrix, int[] expect)
  {
    Assert.Equal(expect, new Solution().SpiralOrder(matrix));
  }
}