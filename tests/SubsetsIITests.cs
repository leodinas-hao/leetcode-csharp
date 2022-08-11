using LeetCode.SubsetsII;

namespace tests;

public class SubsetsIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[]{1,2,2},
      new int[][]{
        new int[]{},
        new int[]{1},
        new int[]{1,2},
        new int[]{1,2,2},
        new int[]{2},
        new int[]{2,2},
      },
    };

    yield return new object[]{
      new int[]{0},
      new int[][]{
        new int[]{},
        new int[]{0},
      },
    };

    yield return new object[]{
      new int[]{4,4,4,1,4},
      new int[][]{
        new int[]{},
        new int[]{1},
        new int[]{1,4},
        new int[]{1,4,4},
        new int[]{1,4,4,4},
        new int[]{1,4,4,4,4},
        new int[]{4},
        new int[]{4,4},
        new int[]{4,4,4},
        new int[]{4,4,4,4},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] nums, int[][] expect)
  {
    var result = new Solution().SubsetsWithDup(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int[] nums, int[][] expect)
  {
    var result = new Solution2().SubsetsWithDup(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}