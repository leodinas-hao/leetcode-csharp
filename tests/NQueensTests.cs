using LeetCode.NQueens;

namespace tests;

public class NQueensTests
{
  [Fact]
  public void TestIsAttacking()
  {
    var len = 3;
    var sol = new Solution();
    var board = sol.InitBoard(len);
    board[1, 1] = true;
    Assert.True(sol.IsAttacking(board, 0, 0));
    Assert.True(sol.IsAttacking(board, 1, 2));
    Assert.True(sol.IsAttacking(board, 2, 2));
    // test board 5
    len = 5;
    board = sol.InitBoard(len);
    board[2, 2] = true;
    Assert.False(sol.IsAttacking(board, 0, 1));
    Assert.False(sol.IsAttacking(board, 1, 4));
    Assert.False(sol.IsAttacking(board, 4, 3));
    Assert.True(sol.IsAttacking(board, 1, 3));
    Assert.True(sol.IsAttacking(board, 0, 4));
    Assert.True(sol.IsAttacking(board, 4, 4));
    Assert.True(sol.IsAttacking(board, 4, 0));
  }

  [Fact]
  public void TestInitBoard()
  {
    var len = 5;
    var board = new Solution().InitBoard(len);
    Assert.Equal(board[0, 0], false);
    Assert.Equal(board.Length, len * len);
  }

  [Fact]
  public void TestPrintBoard()
  {
    var len = 5;
    var sol = new Solution();
    var board = sol.InitBoard(len);
    board[0, 0] = true;
    var printed = sol.PrintBoard(board);
    Assert.Equal(printed.Count(), len);
    Assert.True(printed[0].StartsWith("Q"));
  }

  [Theory]
  [InlineData(1, 1)]
  [InlineData(2, 0)]
  [InlineData(3, 0)]
  [InlineData(4, 2)]
  [InlineData(5, 10)]
  public void Test1(int n, int expect)
  {
    var sol = new Solution();
    var boards = sol.SolveNQueens(n);
    Assert.Equal(boards.Count(), expect);
  }
}