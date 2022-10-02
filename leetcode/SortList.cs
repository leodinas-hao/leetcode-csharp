/*
Sort List
https://leetcode.com/problems/sort-list/

Given the head of a linked list, return the list after sorting it in ascending order.

Example 1:
Input: head = [4,2,1,3]
Output: [1,2,3,4]

Example 2:
Input: head = [-1,5,3,4,0]
Output: [-1,0,3,4,5]

Example 3:
Input: head = []
Output: []

Constraints:
The number of nodes in the list is in the range [0, 5 * 10^4].
-10^5 <= Node.val <= 10^5
*/

namespace LeetCode.SortList;

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
  private ListNode GetMid(ListNode head)
  {
    ListNode midPrev = null;
    while (head != null && head.next != null)
    {
      midPrev = (midPrev == null) ? head : midPrev.next;
      head = head.next.next;
    }
    ListNode mid = midPrev.next;
    midPrev.next = null;
    return mid;
  }

  private ListNode Merge(ListNode l1, ListNode l2)
  {
    ListNode dummy = new ListNode();
    ListNode tail = dummy;
    while (l1 != null && l2 != null)
    {
      if (l1.val < l2.val)
      {
        tail.next = l1;
        l1 = l1.next;
        tail = tail.next;
      }
      else
      {
        tail.next = l2;
        l2 = l2.next;
        tail = tail.next;
      }
    }
    tail.next = (l1 != null) ? l1 : l2;
    return dummy.next;
  }

  public ListNode SortList(ListNode head)
  {
    if (head == null || head.next == null) return head;
    ListNode mid = GetMid(head);
    ListNode left = SortList(head);
    ListNode right = SortList(mid);
    return Merge(left, right);
  }
}


/*
intuitive solution, but get out of memory error on leetcode
*/
public class Solution2
{
  public ListNode SortList(ListNode head)
  {
    if (head == null || head.next == null) return head;

    var heap = new PriorityQueue<ListNode, int>();
    var node = head;
    while (node != null)
    {
      heap.Enqueue(node, node.val);
      node = node.next;
    }
    head = heap.Dequeue();
    node = head;
    while (heap.Count > 0)
    {
      node.next = heap.Dequeue();
      node = node.next;
    }
    return head;
  }
}
