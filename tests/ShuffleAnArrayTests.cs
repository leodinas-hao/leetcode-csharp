using LeetCode.ShuffleAnArray;

namespace tests;

public class ShuffeAnArrayTests
{
  [Fact]
  public void Test1()
  {
    var original = new int[] { 1, 2, 3 };
    var sol = new Solution((int[])original.Clone());
    var s = sol.Shuffle();

    Assert.NotEqual(original, s);
    var r = sol.Reset();
    Assert.Equal(original, r);

    s = sol.Shuffle();
    Assert.NotEqual(original, s);
  }
}