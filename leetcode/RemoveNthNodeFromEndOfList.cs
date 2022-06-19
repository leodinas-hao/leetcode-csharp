/*
Remove Nth Node From End of List
https://leetcode.com/problems/remove-nth-node-from-end-of-list/

Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Example 2:
Input: head = [1], n = 1
Output: []

Example 3:
Input: head = [1,2], n = 1
Output: [1]

Constraints:
The number of nodes in the list is sz.
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz
*/

namespace LeetCode.RemoveNthNodeFromEndOfList;

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
  public ListNode RemoveNthFromEnd(ListNode head, int n)
  {
    List<ListNode> nodes = new List<ListNode>();
    while (head != null)
    {
      nodes.Add(head);
      head = head.next;
    }

    int size = nodes.Count;
    // remove the nth **from the end**
    // calculate the nth node index
    int nth = size - n;
    // the nth node is the only node
    if (size == 1 && n == 1) return null;

    // removing the head node, keep the rest
    if (nth == 0 && size > 1) return nodes[1];

    // update the node pre the nth
    nodes[nth - 1].next = nodes[nth].next;
    return nodes[0];
  }
}

/**
 * after first while loop
 * 0 1 2 3 4 5
 * L   R
 * after second while loop
 * 0 1 2 3 4 5
 *       L   R
 */
public class Solution2
{
  public ListNode RemoveNthFromEnd(ListNode head, int n)
  {
    // modify linked list with a dummy node
    var dummy = new ListNode(0, head);
    // two pointers
    ListNode left = dummy, right = dummy;
    while (n > 0 && right != null)
    {
      right = right.next; // shift right pointer to the nth position
      n--;
    }

    while (right.next != null)
    {
      left = left.next; // shift left pointer to the nth position
      right = right.next; // shift right pointer to the end
    }

    left.next = left.next.next;
    return dummy.next;
  }
}