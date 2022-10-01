using LeetCode.PalindromeLinkedList;

namespace tests;

public class PalindromeLinkedListTests
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
  [InlineData(new int[] { 1, 2 }, false)]
  [InlineData(new int[] { 1, 2, 2, 1 }, true)]
  public void Test1(int[] nums, bool expect)
  {
    var head = ToListNode(nums);
    Assert.Equal(expect, new Solution().IsPalindrome(head));
  }
}