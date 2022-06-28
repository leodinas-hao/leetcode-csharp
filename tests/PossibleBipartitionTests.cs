using LeetCode.PossibleBipartition;

namespace tests;

public class PossibleBipartitionTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      4,
      new int[][]{
        new int[]{1,2},
        new int[]{1,3},
        new int[]{2,4},
      },
      true,
    };
    yield return new object[]{
      3,
      new int[][]{
        new int[]{1,2},
        new int[]{1,3},
        new int[]{2,3},
      },
      false,
    };
    yield return new object[]{
      5,
      new int[][]{
        new int[]{1,2},
        new int[]{2,3},
        new int[]{3,4},
        new int[]{4,5},
        new int[]{1,5},
      },
      false,
    };
    yield return new object[]{
      10,
      new int[][]{
        new int[]{1,2},
        new int[]{3,4},
        new int[]{5,6},
        new int[]{6,7},
        new int[]{8,9},
        new int[]{7,8},
      },
      true,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] dislikes, bool expect)
  {
    Assert.Equal(expect, new Solution().PossibleBipartition(n, dislikes));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int n, int[][] dislikes, bool expect)
  {
    Assert.Equal(expect, new Solution2().PossibleBipartition(n, dislikes));
  }
}
