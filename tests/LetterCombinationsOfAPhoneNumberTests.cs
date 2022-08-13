using LeetCode.LetterCombinationsOfAPhoneNumber;

namespace tests;

public class LetterCombinationsOfAPhoneNumberTests
{
  [Theory]
  [InlineData("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
  [InlineData("", new string[] { })]
  [InlineData("2", new string[] { "a", "b", "c" })]
  public void Test1(string digits, string[] expect)
  {
    var result = new Solution().LetterCombinations(digits);
    Assert.Equal(expect.Length, result.Count);
    Assert.False(expect.Except(result).Any());
  }
}