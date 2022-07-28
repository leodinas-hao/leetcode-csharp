using LeetCode.FindAllAnagramsInAString;

namespace tests;

public class FindAllAnagramsInAStringTests
{
  [Theory]
  [InlineData("cbaebabacd", "abc", new int[] { 0, 6 })]
  [InlineData("abab", "ab", new int[] { 0, 1, 2 })]
  public void Test1(string s, string p, int[] expect)
  {
    var ls = new Solution().FindAnagrams(s, p);
    Assert.Equal(expect.Length, ls.Count);
    foreach (var n in expect)
    {
      Assert.Contains(n, ls);
    }
  }
}