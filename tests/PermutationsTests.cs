using LeetCode.Permutations;

namespace tests;

public class PermutationsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
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
    yield return new object[]{
      new int[]{0,1},
      new int[][]{
        new int[]{0,1},
        new int[]{1,0},
      },
    };
    yield return new object[]{
      new int[]{1},
      new int[][]{
        new int[]{1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] nums, IList<IList<int>> expect)
  {
    var result = new Solution().Permute(nums);
    Assert.Equal(expect.Count, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}
