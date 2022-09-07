using LeetCode.RandomPickWithWeight;

namespace tests;

public class RandomPickWithWeightTests
{
  [Fact]
  public void Test1()
  {
    var sol = new Solution(new int[] { 1, 3 });

    // 3/4 probability to return 1
    // check 10 times and the return array should contain more 1's
    var ans = new int[10];
    for (int i = 0; i < 10; i++)
    {
      ans[i] = sol.PickIndex();
    }
    Assert.True(ans.Count((i) => i == 1) > 5);
  }

  [Fact]
  public void Test2()
  {
    var sol = new Solution(new int[] { 1 });
    // should only be 0 as there is only one element
    Assert.Equal(0, sol.PickIndex());
  }
}
