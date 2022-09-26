using LeetCode.LongestRepeatingCharacterReplacement;

namespace tests;

public class LongestRepeatingCharacterReplacementTests
{
  [Theory]
  [InlineData("AABABBA", 1, 4)]
  [InlineData("ABAB", 2, 4)]
  [InlineData("ABBB", 2, 4)]
  public void Test1(string s, int k, int expect)
  {
    Assert.Equal(expect, new Solution().CharacterReplacement(s, k));
  }
}