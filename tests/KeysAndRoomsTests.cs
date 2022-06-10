using LeetCode.KeysAndRooms;

namespace tests;

public class KeysAndRoomsTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new int[][]{
        new int[]{1},
        new int[]{2},
        new int[]{3},
        new int[]{},
      },
      true,
    };

    yield return new object[] {
      new int[][]{
        new int[]{1, 3},
        new int[]{3, 0, 1},
        new int[]{2},
        new int[]{0},
      },
      false,
    };

    yield return new object[]{
      new int[][]{
        new int[]{6,7,8},
        new int[]{5,4,9},
        new int[]{},
        new int[]{8},
        new int[]{4},
        new int[]{},
        new int[]{1,9,2,3},
        new int[]{7},
        new int[]{6,5},
        new int[]{2,3,1},
      },
      true,
    };

  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] rooms, bool expect)
  {
    var result = new Solution().CanVisitAllRooms(rooms);
    Assert.Equal(expect, result);
  }
}