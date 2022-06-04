using LeetCode.FloodFill;

namespace tests;

public class FloodFillTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } },
      1, 1, 2,
      new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 0 }, new int[] { 2, 0, 1 } },
    };
    yield return new object[] {
      new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } },
      1, 1, 2,
      new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } }
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] image, int sr, int sc, int newColor, int[][] expect)
  {
    var filled = new Solution().FloodFill(image, sr, sc, newColor);
    for (int i = 0; i < filled.Length; i++)
    {
      for (int j = 0; j < filled[0].Length; j++)
      {
        Assert.Equal(expect[i][j], filled[i][j]);
      }
    }
  }
}
