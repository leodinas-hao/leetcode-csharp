using LeetCode.AddTwoNumbersII;

namespace tests;

public class AddTwoNumbersIITests
{
  private ListNode ToListNode(int[] ls)
  {
    var head = new ListNode(ls[0]);
    var node = head;
    for (int i = 1; i < ls.Length; i++)
    {
      node.next = new ListNode(ls[i]);
      node = node.next;
    }
    return head;
  }

  private int[] ToArray(ListNode node)
  {
    if (node == null) return new int[0];
    var ls = new List<int>();
    ls.Add(node.val);
    while (node.next != null)
    {
      node = node.next;
      ls.Add(node.val);
    }
    return ls.ToArray();
  }

  [Theory]
  [InlineData(new int[] { 7, 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 8, 0, 7 })]
  [InlineData(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 8, 0, 7 })]
  [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
  [InlineData(new int[] { 3, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 7 }, new int[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, 6 })]
  public void Test1(int[] l1, int[] l2, int[] expect)
  {
    var node = new Solution().AddTwoNumbers(ToListNode(l1), ToListNode(l2));
    var arr = ToArray(node);
    Assert.Equal(expect.Length, arr.Length);
    for (int i = 0; i < arr.Length; i++)
    {
      Assert.Equal(expect[i], arr[i]);
    }
  }
}
