using LeetCode.MinimumJumpsToReachHome;

namespace tests;

public class MinimumJumpsToReachHomeTests
{
  [Theory]
  [InlineData(new int[] { 14, 4, 18, 1, 15 }, 3, 15, 9, 3)]
  [InlineData(new int[] { 8, 3, 16, 6, 12, 20 }, 15, 13, 11, -1)]
  [InlineData(new int[] { 1, 6, 2, 14, 5, 17, 4 }, 16, 9, 7, 2)]
  [InlineData(new int[] { 1998 }, 1999, 2000, 2000, 3998)]
  [InlineData(new int[] { 1362, 873, 1879, 725, 305, 794, 1135, 1358, 1717, 159, 1370, 1861, 583, 1193, 1921, 778, 1263, 239, 1224, 1925, 1505, 566, 5, 15 }, 560, 573, 64, 1036)]
  [InlineData(new int[] { 162, 118, 178, 152, 167, 100, 40, 74, 199, 186, 26, 73, 200, 127, 30, 124, 193, 84, 184, 36, 103, 149, 153, 9, 54, 154, 133, 95, 45, 198, 79, 157, 64, 122, 59, 71, 48, 177, 82, 35, 14, 176, 16, 108, 111, 6, 168, 31, 134, 164, 136, 72, 98 }, 29, 98, 80, 121)]
  public void Test1(int[] forbidden, int a, int b, int x, int expect)
  {
    var jumps = new Solution().MinimumJumps(forbidden, a, b, x);
    Assert.Equal(expect, jumps);
  }
}
