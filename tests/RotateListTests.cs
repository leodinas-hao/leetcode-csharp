using LeetCode.RotateList;

namespace tests;

public class RotateListTests
{
  private ListNode ToListNode(int[] nums)
  {
    ListNode head = new ListNode(nums[0]);
    ListNode curr = head;
    for (int i = 1; i < nums.Length; i++)
    {
      curr.next = new ListNode(nums[i]);
      curr = curr.next;
    }
    return head;
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 1, 2, 3 })]
  [InlineData(new int[] { 0, 1, 2 }, 4, new int[] { 2, 0, 1 })]
  public void Test1(int[] nums, int k, int[] expect)
  {
    var head = ToListNode(nums);
    var result = new Solution().RotateRight(head, k);
    foreach (var e in expect)
    {
      Assert.Equal(e, result.val);
      result = result.next;
    }
  }
}