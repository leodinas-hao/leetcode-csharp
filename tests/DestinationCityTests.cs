using LeetCode.DestinationCity;

namespace tests;

public class DestinationCityTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new string[][] {
        new string[] { "London", "New York" },
        new string[] { "New York", "Lima" },
        new string[] { "Lima", "Sao Paulo" }
      },
      "Sao Paulo"
    };

    yield return new object[]{
      new string[][]{
        new string[] { "B", "C" },
        new string[] { "D", "B" },
        new string[] { "C", "A" }
      },
      "A"
    };

    yield return new object[]{
      new string[][]{
        new string[] { "A", "Z" }
      },
      "Z"
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(string[][] paths, string expect)
  {
    Assert.Equal(expect, new Solution().DestCity(paths));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(string[][] paths, string expect)
  {
    Assert.Equal(expect, new Solution2().DestCity(paths));
  }
}
