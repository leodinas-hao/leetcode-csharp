using LeetCode.CalculateMondayInLeetcodeBank;

namespace tests;


public class CalculateMondayInLeetcodeBankTest
{
  [Theory]
  [InlineData(4, 10)]
  [InlineData(10, 37)]
  [InlineData(20, 96)]
  public void Test1(int n, int expected)
  {
    Assert.Equal(expected, new Solution().TotalMoney(n));
  }

  [Theory]
  [InlineData(4, 10)]
  [InlineData(10, 37)]
  [InlineData(20, 96)]
  public void Test2(int n, int expected)
  {
    Assert.Equal(expected, new Solution2().TotalMoney(n));
  }
}