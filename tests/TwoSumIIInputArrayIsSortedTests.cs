using LeetCode.TwoSumIIInputArrayIsSorted;

namespace tests;

public class TwoSumIIInputArrayIsSorted
{
  [Theory]
  [InlineData(new int[] { 2, 7, 11, 15 }, 9)]
  [InlineData(new int[] { 2, 3, 4 }, 6)]
  [InlineData(new int[] { -1, 0 }, -1)]
  [InlineData(new int[] { 5, 25, 75 }, 100)]
  public void Test1(int[] numbers, int target)
  {
    var result = new Solution().TwoSum(numbers, target);
    Assert.Equal(2, result.Length);
    Assert.Equal(target, numbers[result[0] - 1] + numbers[result[1] - 1]);
  }

  [Theory]
  [InlineData(new int[] { 2, 7, 11, 15 }, 9)]
  [InlineData(new int[] { 2, 3, 4 }, 6)]
  [InlineData(new int[] { -1, 0 }, -1)]
  [InlineData(new int[] { 5, 25, 75 }, 100)]
  public void Test2(int[] numbers, int target)
  {
    var result = new Solution2().TwoSum(numbers, target);
    Assert.Equal(2, result.Length);
    Assert.Equal(target, numbers[result[0] - 1] + numbers[result[1] - 1]);
  }
}