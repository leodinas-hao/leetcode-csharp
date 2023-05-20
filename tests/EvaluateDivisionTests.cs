using LeetCode.EvaluateDivision;

namespace tests;

public class EvaluateDivisionTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new string[][]{
        new string[]{"a","b"},
        new string[]{"b","c"},
      },
      new double[]{2.0, 3.0},
      new string[][]{
        new string[]{"a","c"},
        new string[]{"b","a"},
        new string[]{"a","e"},
        new string[]{"a","a"},
        new string[]{"x","x"},
      },
      new double[]{6.0, 0.5, -1.0, 1.0, -1.0},
    };
    yield return new object[]{
      new string[][]{
        new string[]{"a","b"},
        new string[]{"b","c"},
        new string[]{"bc","cd"},
      },
      new double[]{1.5,2.5,5.0},
      new string[][]{
        new string[]{"a","c"},
        new string[]{"c","b"},
        new string[]{"bc","cd"},
        new string[]{"cd","bc"},
      },
      new double[]{3.75,0.4,5.0,0.2}
    };
    yield return new object[]{
      new string[][]{
        new string[]{"a","b"},
      },
      new double[]{0.5},
      new string[][]{
        new string[]{"a","b"},
        new string[]{"b","a"},
        new string[]{"a","c"},
        new string[]{"x","y"},
      },
      new double[]{0.5, 2.0, -1.0, -1.0}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(IList<IList<string>> equations, double[] values, IList<IList<string>> queries, double[] expect)
  {
    var result = new Solution().CalcEquation(equations, values, queries);
    Assert.Equal(expect, result);
  }
}