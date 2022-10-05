using LeetCode.TaskScheduler;

namespace tests;

public class TaskSchedulerTests
{
  [Theory]
  [InlineData(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0, 6)]
  [InlineData(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8)]
  [InlineData(new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' }, 2, 16)]
  public void Test1(char[] tasks, int n, int expect)
  {
    Assert.Equal(expect, new Solution().LeastInterval(tasks, n));
  }
}
