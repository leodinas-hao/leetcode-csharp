using LeetCode.SearchA2DMatrixII;

namespace tests;

public class SearchA2DMatrixIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,4,7,11,15},
        new int[]{2,5,8,12,19},
        new int[]{3,6,9,16,22},
        new int[]{10,13,14,17,24},
        new int[]{18,21,23,26,30},
      },
      5,
      true
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,4,7,11,15},
        new int[]{2,5,8,12,19},
        new int[]{3,6,9,16,22},
        new int[]{10,13,14,17,24},
        new int[]{18,21,23,26,30},
      },
      20,
      false
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] matrix, int target, bool expect)
  {
    Assert.Equal(expect, new Solution().SearchMatrix(matrix, target));
  }
}