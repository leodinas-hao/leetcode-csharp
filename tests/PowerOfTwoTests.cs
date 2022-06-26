using LeetCode.PowerOfTwo;

namespace tests;

public class PowerOfTwoTests
{
  [Theory]
  [InlineData(0, false)]
  [InlineData(1, true)]
  [InlineData(16, true)]
  [InlineData(3, false)]
  [InlineData(-1, false)]
  public void Test1(int n, bool expect)
  {
    Assert.Equal(expect, new Solution().IsPowerOfTwo(n));
  }

  [Theory]
  [InlineData(0, false)]
  [InlineData(1, true)]
  [InlineData(16, true)]
  [InlineData(3, false)]
  [InlineData(-1, false)]
  public void Test2(int n, bool expect)
  {
    Assert.Equal(expect, new Solution2().IsPowerOfTwo(n));
  }

  [Theory]
  [InlineData(0, false)]
  [InlineData(1, true)]
  [InlineData(16, true)]
  [InlineData(3, false)]
  [InlineData(-1, false)]
  [InlineData(-2, false)]
  public void Test3(int n, bool expect)
  {
    Assert.Equal(expect, new Solution3().IsPowerOfTwo(n));
  }
}
