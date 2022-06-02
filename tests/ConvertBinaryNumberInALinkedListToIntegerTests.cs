using LeetCode.ConvertBinaryNumberInALinkedListToInteger;

namespace tests;

public class ConvertBinaryNumberInALinkedListToIntegerTests
{
  private ListNode ToLinkedList(int[] bits)
  {
    ListNode curr = new ListNode(bits[0]);
    ListNode head = curr;
    for (int i = 1; i < bits.Length; i++)
    {
      var next = new ListNode(bits[i]);
      curr.next = next;
      curr = next;
    }
    return head;
  }

  [Theory]
  [InlineData(new int[] { 1, 0, 1 }, 5)]
  [InlineData(new int[] { 0 }, 0)]
  public void Test1(int[] bits, int expect)
  {
    var head = ToLinkedList(bits);
    Assert.Equal(head.val, bits[0]);
    var result = new Solution().GetDecimalValue(head);
    Assert.Equal(expect, result);
  }
}