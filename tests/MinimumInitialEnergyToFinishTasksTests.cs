using LeetCode.MinimumInitialEnergyToFinishTasks;

namespace tests;

public class MinimumInitialEnergyToFinishTasksTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[] {
      new int[][] { new int[] { 1, 2 }, new int[] { 2, 4 }, new int[] { 4, 8 } },
      8
    };
    yield return new object[] {
      new int[][] { new int[] { 1, 3 }, new int[] { 2, 4 }, new int[] { 10, 11 }, new int[] { 10, 12 }, new int[] { 8, 9 } },
      32
    };
    yield return new object[] {
      new int[][] {new int[]{ 1, 7 },new int[]{ 2, 8 },new int[]{ 3, 9 },new int[]{ 4, 10 },new int[]{ 5, 11 },new int[]{ 6, 12 },},
      27,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[][] tasks, int expect)
  {
    var result = new Solution().MinimumEffort(tasks);
    Assert.Equal(expect, result);
  }
}