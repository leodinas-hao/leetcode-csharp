using LeetCode.LargestOddNumberInString;

namespace tests;

public class LargestOddNumberInStringTests
{
  [Theory]
  [InlineData("52", "5")]
  [InlineData("4206", "")]
  [InlineData("35427", "35427")]
  public void Test1(string num, string expect)
  {
    Assert.Equal(expect, new Solution().LargestOddNumber(num));
  }
}
