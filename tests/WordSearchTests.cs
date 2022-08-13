using LeetCode.WordSearch;

namespace tests;

public class WordSearchTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new char[][]{
        new char[]{'A','B','C','E'},
        new char[]{'S','F','C','S'},
        new char[]{'A','D','E','E'},
      },
      "ABCCED",
      true,
    };
    yield return new object[]{
      new char[][]{
        new char[]{'A','B','C','E'},
        new char[]{'S','F','C','S'},
        new char[]{'A','D','E','E'},
      },
      "SEE",
      true,
    };
    yield return new object[]{
      new char[][]{
        new char[]{'A','B','C','E'},
        new char[]{'S','F','C','S'},
        new char[]{'A','D','E','E'},
      },
      "ABCB",
      false,
    };

    yield return new object[]{
      new char[][]{
        new char[]{'A','B','C','E'},
        new char[]{'S','F','E','S'},
        new char[]{'A','D','E','E'},
      },
      "ABCESEEEFS",
      true,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(char[][] board, string word, bool expect)
  {
    Assert.Equal(expect, new Solution().Exist(board, word));
  }
}
