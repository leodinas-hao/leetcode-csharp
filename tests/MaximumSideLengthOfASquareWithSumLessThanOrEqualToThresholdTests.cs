using LeetCode.MaximumSideLengthOfASquareWithSumLessThanOrEqualToThreshold;

namespace tests;

public class MaximumSideLengthOfASquareWithSumLessThanOrEqualToThresholdTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[][]{
        new int[]{1,1,3,2,4,3,2},
        new int[]{1,1,3,2,4,3,2},
        new int[]{1,1,3,2,4,3,2},
      },
      4,
      2,
    };

    yield return new object[]{
      new int[][]{
        new int[]{2,2,2,2,2},
        new int[]{2,2,2,2,2},
        new int[]{2,2,2,2,2},
        new int[]{2,2,2,2,2},
        new int[]{2,2,2,2,2},
      },
      1,
      0
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] mat, int threshold, int expect)
  {
    Assert.Equal(expect, new Solution().MaxSideLength(mat, threshold));
  }
}