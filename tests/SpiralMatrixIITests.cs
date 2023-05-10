using LeetCode.SpiralMatrixII;

namespace tests;

public class SpiralMatrixIITests
{

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      3,
      new int[][]{
        new int[]{1,2,3},
        new int[]{8,9,4},
        new int[]{7,6,5},
      },
    };

    yield return new object[]{
      1,
      new int[][]{
        new int[]{1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] expect)
  {
    var matrix = new Solution().GenerateMatrix(n);
    Assert.Equal(expect.Length, matrix.Length);
    for (int i = 0; i < matrix.Length; i++)
    {
      Assert.Equal(expect[i], matrix[i]);
    }
  }
}
