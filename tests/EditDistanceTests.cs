using LeetCode.EditDistance;

namespace tests;

public class EditDistanceTests
{
  [Theory]
  [InlineData("horse", "ros", 3)]
  [InlineData("intention", "execution", 5)]
  public void Test1(string w1, string w2, int expect)
  {
    Assert.Equal(expect, new Solution().MinDistance(w1, w2));
  }
}