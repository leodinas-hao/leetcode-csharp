using LeetCode.NumberOfSubsequencesThatSatisfyTheGivenSumCondition;

namespace tests;

public class NumberOfSubsequencesThatSatisfyTheGivenSumConditionTests
{
  [Theory]
  [InlineData(new int[] { 2, 3, 3, 4, 6, 7 }, 12, 61)]
  [InlineData(new int[] { 3, 3, 6, 8 }, 10, 6)]
  [InlineData(new int[] { 3, 5, 6, 7 }, 9, 4)]
  [InlineData(new int[] { 14, 4, 6, 6, 20, 8, 5, 6, 8, 12, 6, 10, 14, 9, 17, 16, 9, 7, 14, 11, 14, 15, 13, 11, 10, 18, 13, 17, 17, 14, 17, 7, 9, 5, 10, 13, 8, 5, 18, 20, 7, 5, 5, 15, 19, 14 }, 22, 272187084)]
  public void Test1(int[] nums, int target, int expect)
  {
    Assert.Equal(expect, new Solution().NumSubseq(nums, target));
  }

  [Theory]
  [InlineData(new int[] { 2, 3, 3, 4, 6, 7 }, 12, 61)]
  [InlineData(new int[] { 3, 3, 6, 8 }, 10, 6)]
  [InlineData(new int[] { 3, 5, 6, 7 }, 9, 4)]
  [InlineData(new int[] { 14, 4, 6, 6, 20, 8, 5, 6, 8, 12, 6, 10, 14, 9, 17, 16, 9, 7, 14, 11, 14, 15, 13, 11, 10, 18, 13, 17, 17, 14, 17, 7, 9, 5, 10, 13, 8, 5, 18, 20, 7, 5, 5, 15, 19, 14 }, 22, 272187084)]
  public void Test2(int[] nums, int target, int expect)
  {
    Assert.Equal(expect, new Solution2().NumSubseq(nums, target));
  }
}
