using LeetCode.FrequencyOfTheMostFrequentElement;

namespace tests;

public class FrequencyOfTheMostFrequentElementTests
{
  [Theory]
  [InlineData(new int[] { 3, 9, 6 }, 2, 1)]
  [InlineData(new int[] { 1, 4, 8, 13 }, 5, 2)]
  [InlineData(new int[] { 1, 2, 4 }, 5, 3)]
  public void Test1(int[] nums, int k, int expect)
  {
    Assert.Equal(expect, new Solution().MaxFrequency(nums, k));
  }
}
