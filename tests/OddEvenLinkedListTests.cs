using LeetCode.OddEvenLinkedList;

namespace tests;

public class OddEvenLinkedListTests
{
  private ListNode ToListNode(int[] nums)
  {
    var dummy = new ListNode();
    var node = dummy;
    foreach (var num in nums)
    {
      node.next = new ListNode(num);
      node = node.next;
    }
    return dummy.next;
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 5, 2, 4 })]
  [InlineData(new int[] { 2, 1, 3, 5, 6, 4, 7 }, new int[] { 2, 3, 6, 7, 1, 5, 4 })]
  public void Test1(int[] nums, int[] expect)
  {
    var head = ToListNode(nums);
    var sorted = new Solution().OddEvenList(head);
    foreach (var e in expect)
    {
      Assert.Equal(e, sorted.val);
      sorted = sorted.next;
    }
  }
}