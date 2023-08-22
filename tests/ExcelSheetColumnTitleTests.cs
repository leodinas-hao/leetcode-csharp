using System.Security.Cryptography;
using LeetCode.ExcelSheetColumnTitle;

namespace tests;

public class ExcelSheetColumnTitleTests
{
  [Theory]
  [InlineData(1, "A")]
  [InlineData(28, "AB")]
  [InlineData(701, "ZY")]
  public void Test1(int columnNumber, string expect)
  {
    var result = new Solution().ConvertToTitle(columnNumber);
    Assert.Equal(expect, result);
  }
}
