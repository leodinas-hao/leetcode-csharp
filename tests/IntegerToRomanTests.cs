using LeetCode.IntegerToRoman;

namespace tests;


public class IntegerToRomanTests
{
  [Theory]
  [InlineData(3, "III")]
  [InlineData(58, "LVIII")]
  [InlineData(1994, "MCMXCIV")]
  public void Test1(int num, string expect)
  {
    var actual = new Solution().IntToRoman(num);
    Assert.Equal(actual, expect);
  }
}