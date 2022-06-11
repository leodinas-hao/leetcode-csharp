using LeetCode.TheKWeakestRowsInAMatrix;

namespace tests;

public class TheKWeakestRowsInAMatrixTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{1,1,0,0,0},
        new int[]{1,1,1,1,0},
        new int[]{1,0,0,0,0},
        new int[]{1,1,0,0,0},
        new int[]{1,1,1,1,1},
      },
      3,
      new int[]{2,0,3}
    };
    yield return new object[]{
      new int[][] {
        new int[]{1,0,0,0},
        new int[]{1,1,1,1},
        new int[]{1,0,0,0},
        new int[]{1,0,0,0},
      },
      2,
      new int[]{0,2}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int k, int[] expect)
  {
    var result = new Solution().KWeakestRows(mat, k);
    Assert.Equal(k, result.Length);
    for (int i = 0; i < k; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}