using LeetCode.CombinationSumII;

namespace tests;

public class CombinationSumIITests
{
  [Theory]
  [InlineData(new int[] { 2, 5, 2, 1, 2 }, 5, 2)]
  [InlineData(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8, 4)]
  public void Test1(int[] candidates, int target, int expectedCount)
  {
    var result = new Solution().CombinationSum2(candidates, target);
    Assert.Equal(expectedCount, result.Count);
    foreach (var r in result)
    {
      Assert.True(r.Sum() == target);
      Assert.False(r.Except(candidates).Any());
    }
  }
}