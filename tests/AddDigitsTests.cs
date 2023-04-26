using LeetCode.AddDigits;

namespace tests;

public class AddDigitsTests
{
  [Theory]
  [InlineData(38, 2)]
  [InlineData(0, 0)]
  [InlineData(19, 1)]
  public void Test1(int num, int expect)
  {
    Assert.Equal(expect, new Solution().AddDigits(num));
  }

  [Theory]
  [InlineData(38, 2)]
  [InlineData(0, 0)]
  [InlineData(19, 1)]
  public void Test2(int num, int expect)
  {
    Assert.Equal(expect, new Solution2().AddDigits(num));
  }
}
