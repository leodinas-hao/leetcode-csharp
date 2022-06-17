using LeetCode.WaterAndJugProblem;

namespace tests;

public class WaterAndJugProblemTests
{
  [Theory]
  [InlineData(3, 5, 4, true)]
  [InlineData(2, 6, 5, false)]
  [InlineData(1, 2, 3, true)]
  [InlineData(22003, 31237, 1, true)]
  public void Test1(int jug1Capacity, int jug2Capacity, int targetCapacity, bool expect)
  {
    Assert.Equal(expect, new Solution().CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity));
  }

  [Theory]
  [InlineData(3, 5, 4, true)]
  [InlineData(2, 6, 5, false)]
  [InlineData(1, 2, 3, true)]
  [InlineData(22003, 31237, 1, true)]
  public void Test2(int jug1Capacity, int jug2Capacity, int targetCapacity, bool expect)
  {
    Assert.Equal(expect, new Solution2().CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity));
  }
}
