using LeetCode.LinkedListCycleII;

namespace tests;

public class LinkedListCycleIITests
{
  private ListNode ToCycleListNode(int[] nums, int pos)
  {
    if (nums == null || nums.Length == 0) return null;

    ListNode dummy = new ListNode(0);
    ListNode node = dummy;
    ListNode? cycle = null;
    for (int i = 0; i < nums.Length; i++)
    {
      node.next = new ListNode(nums[i]);
      if (i == pos) cycle = node.next;
      node = node.next;
    }
    if (cycle != null) node.next = cycle;
    return dummy.next;
  }

  [Theory]
  [InlineData(new int[] { 3, 2, 0, -4 }, 1)]
  [InlineData(new int[] { 1, 2 }, 0)]
  [InlineData(new int[] { 1 }, -1)]
  public void Test1(int[] nums, int pos)
  {
    var head = ToCycleListNode(nums, pos);
    var cycleNode = new Solution().DetectCycle(head);
    if (pos >= 0)
    {
      for (int i = 0; i < pos; i++) head = head.next;
      Assert.Equal(cycleNode, head);
    }
    else
    {
      Assert.Null(cycleNode);
    }
  }
}
