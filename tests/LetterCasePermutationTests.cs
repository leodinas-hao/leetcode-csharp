using LeetCode.LetterCasePermutation;

namespace tests;

public class LetterCasePermutationTests
{
  [Theory]
  [InlineData("a1b2", new string[] { "a1b2", "a1B2", "A1b2", "A1B2" })]
  [InlineData("3z4", new string[] { "3z4", "3Z4" })]
  public void Test1(string s, string[] expect)
  {
    var result = new Solution().LetterCasePermutation(s);
    foreach (var e in expect)
    {
      Assert.Contains(e, result);
    }
  }
}
