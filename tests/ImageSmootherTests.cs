using LeetCode.ImageSmoother;

namespace tests;


public class ImageSmootherTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,1,1},
        new int[]{1,0,1},
        new int[]{1,1,1},
      },
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,0,0},
        new int[]{0,0,0},
      },
    };
    yield return new object[]{
      new int[][]{
        new int[]{100,200,100},
        new int[]{200,50,200},
        new int[]{100,200,100},
      },
      new int[][]{
        new int[]{137,141,137},
        new int[]{141,138,141},
        new int[]{137,141,137},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] matrix, int[][] expect)
  {
    var result = new Solution().ImageSmoother(matrix);
    Assert.Equal(expect, result);
  }
}