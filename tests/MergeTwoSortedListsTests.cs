using LeetCode.MergeTwoSortedLists;

namespace tests;

public class MergeTwoSortedListsTests
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
  [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4 })]
  [InlineData(new int[] { }, new int[] { }, new int[] { })]
  [InlineData(new int[] { }, new int[] { 0 }, new int[] { 0 })]
  public void Test1(int[] l1, int[] l2, int[] expect)
  {
    var result = new Solution().MergeTwoLists(ToListNode(l1), ToListNode(l2));
    if (expect.Length == 0) Assert.Null(result);
    foreach (var i in expect)
    {
      Assert.Equal(i, result.val);
      result = result.next;
    }
  }
}