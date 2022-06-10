using LeetCode.Search2DMatrix;

namespace tests;

public class Search2DMatrixTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{1,3,5,7},
        new int[]{10,11,16,20},
        new int[]{23,30,34,60},
      },
      3,
      true,
    };
    yield return new object[]{
      new int[][] {
        new int[]{1,3,5,7},
        new int[]{10,11,16,20},
        new int[]{23,30,34,60},
      },
      13,
      false,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] matrix, int target, bool expect)
  {
    bool result = new Solution().SearchMatrix(matrix, target);
    Assert.Equal(expect, result);
  }
}