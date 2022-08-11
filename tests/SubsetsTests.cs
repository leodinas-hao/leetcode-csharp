using LeetCode.Subsets;

namespace tests;

public class SubsetsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[]{1,2,3},
      new int[][]{
        new int[]{},
        new int[]{1},
        new int[]{2},
        new int[]{1,2},
        new int[]{3},
        new int[]{1,3},
        new int[]{2,3},
        new int[]{1,2,3},
      },
    };

    yield return new object[]{
      new int[]{0},
      new int[][]{
        new int[]{},
        new int[]{0},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] nums, int[][] expect)
  {
    var result = new Solution().Subsets(nums);
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
    var result = new Solution2().Subsets(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test3(int[] nums, int[][] expect)
  {
    var mask = Convert.ToString((int)Math.Pow(2, 3 + 1) - 1, 2)[1..];

    var result = new Solution3().Subsets(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}