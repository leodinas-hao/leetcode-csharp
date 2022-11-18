using LeetCode.UglyNumber;

namespace tests;

public class UglyNumberTests
{
  [Theory]
  [InlineData(6, true)]
  [InlineData(1, true)]
  [InlineData(14, false)]
  public void Test1(int n, bool expect)
  {
    Assert.Equal(expect, new Solution().IsUgly(n));
  }
}