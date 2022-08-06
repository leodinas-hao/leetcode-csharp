using LeetCode.ThreeSum;

namespace tests;

public class ThreeSumTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int[]{0,0,0},
      new int[][]{
        new int[]{0,0,0}
      },
    };
    yield return new object[]{
      new int[]{0,1,1},
      new int[][]{},
    };
    yield return new object[]{
      new int[]{-1,0,1,2,-1,-4},
      new int[][]{
        new int[]{-1,-1,2},
        new int[]{-1,0,1},
      }
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] nums, int[][] expect)
  {
    var result = new Solution().ThreeSum(nums);
    Assert.Equal(expect.Length, result.Count);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}
