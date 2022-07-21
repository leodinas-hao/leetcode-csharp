using LeetCode.AddBinary;

namespace tests;

public class AddBinaryTests
{
  [Theory]
  [InlineData("11", "1", "100")]
  [InlineData("1010", "1011", "10101")]
  public void Test1(string a, string b, string expect)
  {
    Assert.Equal(expect, new Solution().AddBinary(a, b));
  }
}
