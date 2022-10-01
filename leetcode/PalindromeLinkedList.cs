/*
Palindrome Linked List
https://leetcode.com/problems/palindrome-linked-list/

Given the head of a singly linked list, return true if it is a palindrome or false otherwise.

Example 1:
1->2->2->1
Input: head = [1,2,2,1]
Output: true

Example 2:
1->2
Input: head = [1,2]
Output: false

Constraints:
The number of nodes in the list is in the range [1, 105].
0 <= Node.val <= 9
*/

namespace LeetCode.PalindromeLinkedList;

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
  public bool IsPalindrome(ListNode head)
  {
    var nodes = new List<ListNode>();
    while (head != null)
    {
      nodes.Add(head);
      head = head.next;
    }
    if (nodes.Count == 0) return false;
    int left = 0, right = nodes.Count - 1;
    while (left <= right)
    {
      if (nodes[left].val == nodes[right].val)
      {
        left++;
        right--;
      }
      else return false;
    }
    return true;
  }
}