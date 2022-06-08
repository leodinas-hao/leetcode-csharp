using LeetCode.TopKFrequentElements;

namespace tests;

public class TopKFrequentElementsTests
{
  [Theory]
  [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
  [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
  public void Test1(int[] nums, int k, int[] expect)
  {
    var result = new Solution().TopKFrequent(nums, k);
    Assert.Equal(k, result.Length);
    foreach (var r in result)
    {
      Assert.True(expect.Contains(r));
    }
  }
}