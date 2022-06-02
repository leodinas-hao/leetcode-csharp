using LeetCode.DecompressRunLengthEncodedList;

namespace tests;

public class DecompressRunLengthEncodedListTests
{
  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4, 4, 4 })]
  [InlineData(new int[] { 1, 1, 2, 3 }, new int[] { 1, 3, 3 })]
  public void Test1(int[] nums, int[] expect)
  {
    var ls = new Solution().DecompressRLElist(nums);
    Assert.Equal(expect.Length, ls.Length);
    for (int i = 0; i < expect.Length; i++)
    {
      Assert.Equal(expect[i], ls[i]);
    }
  }
}
