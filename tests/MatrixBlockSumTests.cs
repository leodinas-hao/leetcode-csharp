using LeetCode.MatrixBlockSum;

namespace tests;

public class MatrixBlockSumTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{4,5,6},
        new int[]{7,8,9},
      },
      1,
      new int[][]{
        new int[]{12,21,16},
        new int[]{27,45,33},
        new int[]{24,39,28},
      },
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{4,5,6},
        new int[]{7,8,9},
      },
      2,
      new int[][]{
        new int[]{45,45,45},
        new int[]{45,45,45},
        new int[]{45,45,45},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int k, int[][] expect)
  {
    var result = new Solution().MatrixBlockSum(mat, k);
    Assert.Equal(expect.Length, mat.Length);
    for (int i = 0; i < expect.Length; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}