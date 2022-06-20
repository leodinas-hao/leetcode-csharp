using LeetCode.OpenTheLock;

namespace tests;

public class OpenTheLockTests
{
  [Theory]
  [InlineData(new string[] { "0201", "0101", "0102", "1212", "2002" }, "0202", 6)]
  [InlineData(new string[] { "8888" }, "0009", 1)]
  [InlineData(new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888", -1)]
  public void Test1(string[] deadends, string target, int expect)
  {
    var result = new Solution().OpenLock(deadends, target);
    Assert.Equal(expect, result);
  }
}
