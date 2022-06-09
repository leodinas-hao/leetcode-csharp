using LeetCode.Matrix01;

namespace tests;

public class Matrix01Tests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{0,0,0},
      },
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{0,0,0},
      },
    };
    yield return new object[]{
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{1,1,1},
      },
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{1,2,1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int[][] expect)
  {
    var result = new Solution().UpdateMatrix(mat);
    for (int i = 0; i < mat.Length; i++)
    {
      for (int j = 0; j < mat[0].Length; j++)
      {
        Assert.Equal(expect[i][j], result[i][j]);
      }
    }
  }
}
