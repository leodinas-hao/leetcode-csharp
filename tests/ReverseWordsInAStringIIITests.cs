using LeetCode.ReverseWordsInAStringIII;

namespace tests;

public class ReverseWordsInAStringIIITests
{
  [Theory]
  [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
  [InlineData("God Ding", "doG gniD")]
  public void Test1(string s, string expect)
  {
    var reversed = new Solution().ReverseWords(s);
    Assert.Equal(expect, reversed);
  }

  [Theory]
  [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
  [InlineData("God Ding", "doG gniD")]
  public void Test2(string s, string expect)
  {
    var reversed = new Solution2().ReverseWords(s);
    Assert.Equal(expect, reversed);
  }
}