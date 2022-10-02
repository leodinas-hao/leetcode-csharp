using LeetCode.SortList;

namespace tests;

public class SortListTests
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
  [InlineData(new int[] { }, new int[] { })]
  [InlineData(new int[] { 4, 2, 1, 3 }, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { -1, 5, 3, 4, 0 }, new int[] { -1, 0, 3, 4, 5 })]
  public void Test1(int[] nums, int[] expect)
  {
    var head = ToListNode(nums);
    var sorted = new Solution().SortList(head);
    foreach (var e in expect)
    {
      Assert.Equal(e, sorted.val);
      sorted = sorted.next;
    }
  }

  [Theory]
  [InlineData(new int[] { }, new int[] { })]
  [InlineData(new int[] { 4, 2, 1, 3 }, new int[] { 1, 2, 3, 4 })]
  [InlineData(new int[] { -1, 5, 3, 4, 0 }, new int[] { -1, 0, 3, 4, 5 })]
  public void Test2(int[] nums, int[] expect)
  {
    var head = ToListNode(nums);
    var sorted = new Solution2().SortList(head);
    foreach (var e in expect)
    {
      Assert.Equal(e, sorted.val);
      sorted = sorted.next;
    }
  }
}