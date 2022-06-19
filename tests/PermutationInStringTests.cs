using LeetCode.PermutationInString;

namespace tests;

public class PermutationInStringTests
{
  [Theory]
  [InlineData("ab", "eidbaooo", true)]
  [InlineData("ab", "eidboaoo", false)]
  public void Test1(string s1, string s2, bool expect)
  {
    Assert.Equal(expect, new Solution().CheckInclusion(s1, s2));
  }
}
