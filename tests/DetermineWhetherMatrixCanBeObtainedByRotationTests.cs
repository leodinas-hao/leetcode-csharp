using LeetCode.DetermineWhetherMatrixCanBeObtainedByRotation;

namespace tests;

public class DetermineWhetherMatrixCanBeObtainedByRotationTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{0,1},
        new int[]{1,0}
      },
      new int[][]{
        new int[]{1,0},
        new int[]{0,1}
      },
      true,
    };

    yield return new object[]{
      new int[][]{
        new int[]{0,1},
        new int[]{1,1},
      },
      new int[][]{
        new int[]{1,0},
        new int[]{0,1},
      },
      false,
    };

    yield return new object[]{
      new int[][]{
        new int[]{0,0,0},
        new int[]{0,1,0},
        new int[]{1,1,1},
      },
      new int[][]{
        new int[]{1,1,1},
        new int[]{0,1,0},
        new int[]{0,0,0},
      },
      true,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int[][] target, bool expect)
  {
    Assert.Equal(expect, new Solution().FindRotation(mat, target));
  }

}
