using LeetCode.RemoveDuplicatesFromSortedListII;

namespace tests;

public class RemoveDuplicatesFromSortedListIITests
{
  private ListNode ToListNode(int[] nums)
  {
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
  [InlineData(new int[] { 1, 1, 1, 2, 3 }, new int[] { 2, 3 })]
  [InlineData(new int[] { 1, 2, 3, 3, 4, 4, 5 }, new int[] { 1, 2, 5 })]
  public void Test1(int[] nums, int[] expect)
  {
    var result = new Solution().DeleteDuplicates(ToListNode(nums));
    foreach (int e in expect)
    {
      Assert.Equal(e, result.val);
      result = result.next;
    }
  }
}