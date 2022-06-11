using LeetCode.NumberOfProvinces;

namespace tests;

public class NumberOfProvincesTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][] {
        new int[]{1,1,0},
        new int[]{1,1,0},
        new int[]{0,0,1},
      },
      2
    };
    yield return new object[]{
      new int[][]{
        new int[]{1,0,0},
        new int[]{0,1,0},
        new int[]{0,0,1},
      },
      3
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] isConnected, int expect)
  {
    var provinces = new Solution().FindCircleNum(isConnected);
    Assert.Equal(expect, provinces);
  }
}