using LeetCode.FindAPeakElementII;

namespace test;

public class FindAPeakElementIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,4},
        new int[]{3,2},
      },
      new int[][]{
        new int[]{1,0},
        new int[]{0,1},
      },
    };
    yield return new object[]{
      new int[][]{
        new int[]{10,20,15},
        new int[]{21,30,14},
        new int[]{7,16,32},
      },
      new int[][]{
        new int[]{1,1},
        new int[]{2,2},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int[][] expect)
  {
    var result = new Solution().FindPeakGrid(mat);
    Assert.True(expect.Any((e) => e[0] == result[0] && e[1] == result[1]));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[][] mat, int[][] expect)
  {
    var result = new Solution2().FindPeakGrid(mat);
    Assert.True(expect.Any((e) => e[0] == result[0] && e[1] == result[1]));
  }
}