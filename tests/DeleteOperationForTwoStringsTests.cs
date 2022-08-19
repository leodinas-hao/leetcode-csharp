using LeetCode.DeleteOperationForTwoStrings;

namespace tests;

public class DeleteOperationForTwoStringsTests
{
  [Theory]
  [InlineData("sea", "eat", 2)]
  [InlineData("leetcode", "etco", 4)]
  public void Test1(string w1, string w2, int expect)
  {
    Assert.Equal(expect, new Solution().MinDistance(w1, w2));
  }
}
