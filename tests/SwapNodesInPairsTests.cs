using LeetCode.SwapNodesInPairs;

namespace tests;

public class SwapNodesInPairsTests
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
  [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 })]
  [InlineData(new int[] { 1 }, new int[] { 1 })]
  [InlineData(new int[] { }, new int[] { })]
  public void Test1(int[] ls, int[] expect)
  {
    var node = ToListNode(ls);
    var result = new Solution().SwapPairs(node);
    foreach (int i in expect)
    {
      Assert.Equal(i, result.val);
      result = result.next;
    }
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 })]
  [InlineData(new int[] { 1 }, new int[] { 1 })]
  [InlineData(new int[] { }, new int[] { })]
  public void Test2(int[] ls, int[] expect)
  {
    var node = ToListNode(ls);
    var result = new Solution2().SwapPairs(node);
    foreach (int i in expect)
    {
      Assert.Equal(i, result.val);
      result = result.next;
    }
  }
}
