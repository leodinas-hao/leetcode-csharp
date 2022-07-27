using LeetCode.GroupAnagrams;

namespace tests;

public class GroupAnagramsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new string[]{"eat","tea","tan","ate","nat","bat"},
      new string[][]{
        new string[]{"bat"},
        new string[]{"nat","tan"},
        new string[]{"ate","eat","tea"}
      },
    };

    yield return new object[]{
      new string[]{""},
      new string[][]{
        new string[]{""}
      },
    };

    yield return new object[]{
      new string[]{"a"},
      new string[][]{
        new string[]{"a"}
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(string[] strs, string[][] expect)
  {
    var result = new Solution().GroupAnagrams(strs);
    Assert.Equal(expect.Length, result.Count);
  }
}
