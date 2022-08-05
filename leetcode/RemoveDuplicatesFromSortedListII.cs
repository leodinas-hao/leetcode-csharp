/*
Remove Duplicates from Sorted List II
https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/

Given the head of a sorted linked list, delete all nodes that have duplicate numbers, 
leaving only distinct numbers from the original list. Return the linked list sorted as well.

Example 1:
1 -> 2 -> 3 -> 3 -> 4 -> 4 -> 5
to:
1 -> 2 -> 5
Input: head = [1,2,3,3,4,4,5]
Output: [1,2,5]

Example 2:
Input: head = [1,1,1,2,3]
Output: [2,3]

Constraints:
The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
*/

namespace LeetCode.RemoveDuplicatesFromSortedListII;

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
  public ListNode DeleteDuplicates(ListNode head)
  {
    // create a dummy node to hold the head as next node
    var dummy = new ListNode(0, head);

    // keep track of the last node
    var prev = dummy;

    while (head != null)
    {
      // find duplicates
      if (head.next != null && head.val == head.next.val)
      {
        // move till the end of duplicates
        while (head.next != null && head.val == head.next.val)
        {
          head = head.next;
        }
        // skip duplicates
        prev.next = head.next;
      }
      else
      {
        prev = prev.next;
      }

      // move to next node
      head = head.next;
    }

    return dummy.next;
  }
}
