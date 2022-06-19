using LeetCode.FindTheTownJudge;

namespace tests;

public class FindTheTownJudgeTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      2,
      new int[][]{
        new int[]{1,2},
      },
      2
    };
    yield return new object[]{
      3,
      new int[][]{
        new int[]{1,3},
        new int[]{2,3},
      },
      3
    };
    yield return new object[]{
      3,
      new int[][]{
        new int[]{1,3},
        new int[]{2,3},
        new int[]{3,1},
      },
      -1
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int n, int[][] trust, int expect)
  {
    var judge = new Solution().FindJudge(n, trust);
    Assert.Equal(expect, judge);
  }
}