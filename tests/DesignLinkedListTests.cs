using LeetCode.DesignLinkedList;

namespace tests;

public class DesignLinkedListTests
{
  [Fact]
  public void Test1()
  {
    MyLinkedList myLinkedList = new MyLinkedList();
    myLinkedList.AddAtHead(1);
    myLinkedList.AddAtTail(3);
    myLinkedList.AddAtIndex(1, 2);    // linked list becomes 1->2->3
    Assert.Equal(2, myLinkedList.Get(1));              // return 2
    myLinkedList.DeleteAtIndex(1);    // now the linked list is 1->3
    Assert.Equal(3, myLinkedList.Get(1));              // return 3
  }
}
