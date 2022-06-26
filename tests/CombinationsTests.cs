using LeetCode.Combinations;

namespace tests;

public class CombinationsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      4,
      2,
      new int[][]{
        new int[]{2,4},
        new int[]{3,4},
        new int[]{2,3},
        new int[]{1,2},
        new int[]{1,3},
        new int[]{1,4},
      },
    };
    yield return new object[]{
      1,
      1,
      new int[][]{
        new int[]{1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int k, IList<IList<int>> expect)
  {
    var result = new Solution().Combine(n, k);
    Assert.Equal(expect.Count, result.Count);
    foreach (var r in result)
    {
      // // order the inner array of result
      Assert.Contains(r.OrderBy(r => r).ToArray(), expect);
    }
  }
}