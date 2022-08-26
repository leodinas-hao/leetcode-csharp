using LeetCode.FindTheStudentThatWillReplaceTheChalk;

namespace tests;

public class FindTheStudentThatWillReplaceTheChalkTests
{
  [Theory]
  [InlineData(new int[] { 5, 1, 5 }, 22, 0)]
  [InlineData(new int[] { 3, 4, 1, 2 }, 25, 1)]
  public void Test1(int[] chalk, int k, int expect)
  {
    Assert.Equal(expect, new Solution().ChalkReplacer(chalk, k));
  }
}