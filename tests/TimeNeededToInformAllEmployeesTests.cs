using LeetCode.TimeNeededToInformAllEmployees;

namespace tests;

public class TimeNeededToInformAllEmployeesTests
{
  [Theory]
  [InlineData(1, 0, new int[] { -1 }, new int[] { 0 }, 0)]
  [InlineData(6, 2, new int[] { 2, 2, -1, 2, 2, 2 }, new int[] { 0, 0, 1, 0, 0, 0 }, 1)]
  public void Test1(int n, int headID, int[] manager, int[] informTime, int expect)
  {
    var result = new Solution().NumOfMinutes(n, headID, manager, informTime);
    Assert.Equal(expect, result);
  }
}
