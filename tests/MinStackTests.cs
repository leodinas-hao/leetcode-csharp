using LeetCode.MinStack;

namespace tests;

public class MinStackTests
{
  [Fact]
  public void Test1()
  {
    MinStack minStack = new MinStack();
    minStack.Push(-2);
    minStack.Push(0);
    minStack.Push(-3);
    Assert.Equal(-3, minStack.GetMin()); // return -3
    minStack.Pop();
    Assert.Equal(0, minStack.Top());    // return 0
    Assert.Equal(-2, minStack.GetMin()); // return -2
  }
}