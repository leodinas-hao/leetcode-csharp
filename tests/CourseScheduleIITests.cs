using LeetCode.CourseScheduleII;

namespace tests;

public class CourseScheduleIITests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      2,
      new int[][]{
        new int[]{1,0}
      },
      true,
    };
    yield return new object[]{
      4,
      new int[][]{
        new int[]{1,0},
        new int[]{2,0},
        new int[]{3,1},
        new int[]{3,2},
      },
      true,
    };
    yield return new object[]{
      1,
      new int[][]{},
      true
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int numCourses, int[][] prerequisites, bool possible)
  {
    var result = new Solution().FindOrder(numCourses, prerequisites);
    if (possible)
    {
      Assert.Equal(numCourses, result.Length);
      // check each prerequisite to verify the sequence is correct
      foreach (var pre in prerequisites)
      {
        int c1 = result.TakeWhile(c => c != pre[0]).Count();
        int c2 = result.TakeWhile(c => c != pre[1]).Count();
        Assert.True(c1 > c2);
      }
    }
    else
    {
      Assert.Equal(0, result.Length);
    }
  }
}