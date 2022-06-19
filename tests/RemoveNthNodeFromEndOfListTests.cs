using LeetCode.RemoveNthNodeFromEndOfList;

namespace tests;

public class RemoveNthNodeFromEndOfListTests
{
  private ListNode ToListNode(int[] nodes)
  {
    if (nodes.Length == 0) return null;
    var head = new ListNode(nodes[0]);
    var node = head;
    for (int i = 1; i < nodes.Length; i++)
    {
      node.next = new ListNode(nodes[i]);
      node = node.next;
    }
    return head;
  }

  [Theory]
  [InlineData(new int[] { 1 }, 1, new int[] { })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
  [InlineData(new int[] { 1, 2 }, 1, new int[] { 1 })]
  [InlineData(new int[] { 1, 2 }, 2, new int[] { 2 })]
  public void Test1(int[] nodes, int n, int[] expect)
  {
    var node = new Solution().RemoveNthFromEnd(ToListNode(nodes), n);
    foreach (int e in expect)
    {
      Assert.Equal(e, node.val);
      node = node.next;
    }
  }
}