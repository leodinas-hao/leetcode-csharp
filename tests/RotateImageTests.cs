using LeetCode.RotateImage;

namespace tests;

public class RotateImageTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,2,3},
        new int[]{4,5,6},
        new int[]{7,8,9}
      },
      new int[][]{
        new int[]{7,4,1},
        new int[]{8,5,2},
        new int[]{9,6,3},
      }
    };

    yield return new object[]{
      new int[][]{
        new int[]{5,1,9,11},
        new int[]{2,4,8,10},
        new int[]{13,3,6,7},
        new int[]{15,14,12,16}
      },
      new int[][]{
        new int[]{15,13,2,5},
        new int[]{14,3,4,1},
        new int[]{12,6,8,9},
        new int[]{16,7,10,11},
      }
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int[][] expect)
  {
    new Solution().Rotate(mat);
    for (int i = 0; i < mat.Length; i++)
    {
      for (int j = 0; j < mat[0].Length; j++)
      {
        Assert.Equal(expect[i][j], mat[i][j]);
      }
    }
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] mat, int[][] expect)
  {
    new Solution2().Rotate(mat);
    for (int i = 0; i < mat.Length; i++)
    {
      for (int j = 0; j < mat[0].Length; j++)
      {
        Assert.Equal(expect[i][j], mat[i][j]);
      }
    }
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test3(int[][] mat, int[][] expect)
  {
    new Solution3().Rotate(mat);
    for (int i = 0; i < mat.Length; i++)
    {
      for (int j = 0; j < mat[0].Length; j++)
      {
        Assert.Equal(expect[i][j], mat[i][j]);
      }
    }
  }
}
