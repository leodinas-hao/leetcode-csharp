/*
rotate list
https://leetcode.com/problems/rotate-list/

Given the head of a linked list, rotate the list to the right by k places.

Example 1:
Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]

Example 2:
Input: head = [0,1,2], k = 4
Output: [2,0,1]

Constraints:
The number of nodes in the list is in the range [0, 500].
-100 <= Node.val <= 100
0 <= k <= 2 * 10^9
*/

namespace LeetCode.RotateList;

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
  public ListNode RotateRight(ListNode head, int k)
  {
    if (head == null) return null;

    var stack = new Stack<ListNode>();
    var node = head;
    var count = 0;
    while (node != null)
    {
      stack.Push(node);
      node = node.next;
      count++;
    }

    k = k % count;

    while (k > 0)
    {
      var lastNode = stack.Pop();
      lastNode.next = head;

      // remove the 2nd last node's next (avoid circular linkage)
      if (stack.Any()) stack.Peek().next = null;

      head = lastNode;
      k--;
    }

    return head;
  }
}
