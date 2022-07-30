using LeetCode.AddTwoNumbers;

namespace tests;

public class AddTwoNumbersTests
{
  private ListNode ToListNode(int[] nums)
  {
    if (nums == null || nums.Length == 0) return null;
    var head = new ListNode(nums[0]);
    var node = head;
    for (int i = 1; i < nums.Length; i++)
    {
      node.next = new ListNode(nums[i]);
      node = node.next;
    }
    return head;
  }

  [Theory]
  [InlineData(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
  [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
  [InlineData(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
  public void Test1(int[] l1, int[] l2, int[] expect)
  {
    var result = new Solution().AddTwoNumbers(ToListNode(l1), ToListNode(l2));
    foreach (var n in expect)
    {
      Assert.Equal(n, result.val);
      result = result.next;
    }
  }
}