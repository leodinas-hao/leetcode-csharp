/*
Reorder List
https://leetcode.com/frontendx/problems/reorder-list/

You are given the head of a singly linked-list. The list can be represented as:
L0 → L1 → … → Ln - 1 → Ln
Reorder the list to be on the following form:
L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
You may not modify the values in the list's nodes. Only nodes themselves may be changed.

Example 1:
1->2->3->4  to  1->4->2->3
Input: head = [1,2,3,4]
Output: [1,4,2,3]

Example 2:
1->2->3->4->5  to  1->5->2->4->3
Input: head = [1,2,3,4,5]
Output: [1,5,2,4,3]

Constraints:
The number of nodes in the list is in the range [1, 5 * 10^4].
1 <= Node.val <= 1000
*/

namespace LeetCode.ReorderList;

/**
 * Definition for singly-linked list.
 */
public class ListNode
{
  public int val;
  public ListNode next;
  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class Solution
{
  public void ReorderList(ListNode head)
  {
    // no change required
    if (head == null || head.next == null) return;

    // load each node into a stack
    var stack = new Stack<ListNode>();
    var node = head;
    while (node != null)
    {
      stack.Push(node);
      node = node.next;
    }

    int count = stack.Count;
    for (int i = 0; i < count / 2; i++)
    {
      var oldNext = head.next;
      head.next = stack.Pop();
      head.next.next = oldNext;
      head = head.next.next;
    }
    // set the last next node of the last
    head.next = null;
  }
}