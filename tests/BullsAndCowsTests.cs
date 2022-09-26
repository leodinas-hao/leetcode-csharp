using LeetCode.BullsAndCows;

namespace tests;

public class BullsAndCowsTests
{
  [Theory]
  [InlineData("1807", "7810", "1A3B")]
  [InlineData("1123", "0111", "1A1B")]
  [InlineData("1122", "1222", "3A0B")]
  public void Test1(string secret, string guess, string expect)
  {
    Assert.Equal(expect, new Solution().GetHint(secret, guess));
  }
}