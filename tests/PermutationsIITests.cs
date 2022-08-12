using LeetCode.PermutationsII;

namespace tests;

public class PermutationsIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[]{1,1,2},
      new int[][]{
        new int[]{1,1,2},
        new int[]{1,2,1},
        new int[]{2,1,1},
      },
    };

    yield return new object[]{
      new int[]{1,2,3},
      new int[][]{
        new int[]{1,2,3},
        new int[]{1,3,2},
        new int[]{2,1,3},
        new int[]{2,3,1},
        new int[]{3,1,2},
        new int[]{3,2,1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] nums, int[][] expect)
  {
    var result = new Solution().PermuteUnique(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}