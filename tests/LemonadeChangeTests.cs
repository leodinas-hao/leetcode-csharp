using LeetCode.LemonadeChange;

namespace tests;

public class LemonadeChangeTests
{
  [Theory]
  [InlineData(new int[] { 5, 5, 5, 10, 20 }, true)]
  [InlineData(new int[] { 5, 5, 10, 10, 20 }, false)]
  public void Test1(int[] bills, bool expect)
  {
    Assert.Equal(expect, new Solution().LemonadeChange(bills));
  }
}