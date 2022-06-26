using LeetCode.ClimbingStairs;

namespace tests;

public class ClimbingStairsTests
{
  [Theory]
  [InlineData(2, 2)]
  [InlineData(3, 3)]
  public void Test1(int n, int expect)
  {
    Assert.Equal(expect, new Solution().ClimbStairs(n));
  }

  [Theory]
  [InlineData(2, 2)]
  [InlineData(3, 3)]
  public void Test2(int n, int expect)
  {
    Assert.Equal(expect, new Solution2().ClimbStairs(n));
  }
}
