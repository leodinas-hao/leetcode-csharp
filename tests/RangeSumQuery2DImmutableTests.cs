using LeetCode.RangeSumQuery2DImmutable;

namespace tests;

public class RangeSumQuery2DImmutableTests
{
  [Fact]
  public void Test1()
  {
    var matrix = new int[][]{
      new int[]{3, 0, 1, 4, 2},
      new int[]{5, 6, 3, 2, 1},
      new int[]{1, 2, 0, 1, 5},
      new int[]{4, 1, 0, 1, 7},
      new int[]{1, 0, 3, 0, 5},
    };

    NumMatrix numMatrix = new NumMatrix(matrix);
    Assert.Equal(8, numMatrix.SumRegion(2, 1, 4, 3)); // return 8 (i.e sum of the red rectangle)
    Assert.Equal(11, numMatrix.SumRegion(1, 1, 2, 2)); // return 11 (i.e sum of the green rectangle)
    Assert.Equal(12, numMatrix.SumRegion(1, 2, 2, 4)); // return 12 (i.e sum of the blue rectangle)
  }
}
