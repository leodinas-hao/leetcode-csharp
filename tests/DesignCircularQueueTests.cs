using LeetCode.DesignCircularQueue;

namespace tests;

public class DesignCircularQueueTests
{
  [Fact]
  public void Test1()
  {
    MyCircularQueue queue = new MyCircularQueue(3);
    Assert.True(queue.EnQueue(1)); // return True
    Assert.True(queue.EnQueue(2)); // return True
    Assert.True(queue.EnQueue(3)); // return True
    Assert.False(queue.EnQueue(4)); // return False
    Assert.Equal(3, queue.Rear());     // return 3
    Assert.True(queue.IsFull());   // return True
    Assert.True(queue.DeQueue());  // return True
    Assert.True(queue.EnQueue(4)); // return True
    Assert.Equal(4, queue.Rear());     // return 4
  }
}