using LeetCode.RemovingStarsFromAString;

namespace tests;

public class RemovingStarsFromAStringTests
{
  [Theory]
  [InlineData("erase*****", "")]
  [InlineData("leet**cod*e", "lecoe")]
  public void Test1(string s, string expect)
  {
    var result = new Solution().RemoveStars(s);
    Assert.Equal(result, expect);
  }

  [Theory]
  [InlineData("erase*****", "")]
  [InlineData("leet**cod*e", "lecoe")]
  public void Test2(string s, string expect)
  {
    var result = new Solution2().RemoveStars(s);
    Assert.Equal(result, expect);
  }
}