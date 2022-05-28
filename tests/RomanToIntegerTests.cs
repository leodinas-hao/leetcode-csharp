using LeetCode.RomanToInteger;

namespace tests;


public class RomanToIntegerTests
{
  [Theory]
  [InlineData("III", 3)]
  [InlineData("LVIII", 58)]
  [InlineData("MCMXCIV", 1994)]
  public void Test1(string roman, int expect)
  {
    var actual = new Solution().RomanToInt(roman);
    Assert.Equal(actual, expect);
  }
}