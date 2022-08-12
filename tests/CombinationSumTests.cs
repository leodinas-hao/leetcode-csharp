using LeetCode.CombinationSum;

namespace tests;

public class CombinationSumTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[]{2,3,6,7},
      7,
      new int[][]{
        new int[]{2,2,3},
        new int[]{7}
      }
    };

    yield return new object[]{
      new int[]{2,3,5},
      8,
      new int[][]{
        new int[]{2,2,2,2},
        new int[]{2,3,3},
        new int[]{3,5},
      }
    };

    yield return new object[]{
      new int[]{2},
      1,
      new int[][]{}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] candidates, int target, int[][] expect)
  {
    var result = new Solution().CombinationSum(candidates, target);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}