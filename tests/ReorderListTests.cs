using LeetCode.ReorderList;

namespace tests;

public class ReorderListTests
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
  [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4, 2, 3 })]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 5, 2, 4, 3 })]
  public void Test1(int[] nums, int[] expect)
  {
    var head = ToListNode(nums);
    new Solution().ReorderList(head);

    foreach (int e in expect)
    {
      Assert.Equal(e, head.val);
      head = head.next;
    }
  }
}
