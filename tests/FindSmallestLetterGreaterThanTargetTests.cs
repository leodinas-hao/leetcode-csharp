using LeetCode.FindSmallestLetterGreaterThanTarget;

namespace tests;

public class FindSmallestLetterGreaterThanTargetTests
{
  [Theory]
  [InlineData(new char[] { 'c', 'f', 'j' }, 'a', 'c')]
  [InlineData(new char[] { 'c', 'f', 'j' }, 'c', 'f')]
  [InlineData(new char[] { 'c', 'f', 'j' }, 'd', 'f')]
  public void Test1(char[] letters, char target, char expect)
  {
    char c = new Solution().NextGreatestLetter(letters, target);
    Assert.Equal(expect, c);
  }
}

