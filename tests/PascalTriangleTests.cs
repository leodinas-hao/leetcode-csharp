using LeetCode.PascalTriangle;

namespace tests;

public class PascalTriangleTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      5,
      new int[][]{
        new int[]{1},
        new int[]{1,1},
        new int[]{1,2,1},
        new int[]{1,3,3,1},
        new int[]{1,4,6,4,1},
      },
    };

    yield return new object[]{
      1,
      new int[][]{
        new int[]{1},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, IList<IList<int>> expect)
  {
    var result = new Solution().Generate(n);
    Assert.Equal(n, result.Count);
    for (int i = 0; i < n; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}