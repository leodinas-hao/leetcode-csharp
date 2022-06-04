/*
Add Two Numbers II
https://leetcode.com/problems/add-two-numbers-ii/

You are given two non-empty linked lists representing two non-negative integers. 
The most significant digit comes first and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
  7->2->4->3
+    5->6->4
------------
  7->8->0->7
Input: l1 = [7,2,4,3], l2 = [5,6,4]
Output: [7,8,0,7]

Example 2:
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [8,0,7]

Example 3:
Input: l1 = [0], l2 = [0]
Output: [0]

Constraints:
The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.

Note:
The numbers could be as long as 100 length!
*/

namespace LeetCode.AddTwoNumbersII;


// Definition for singly-linked list
public class ListNode
{
  public int val;
  public ListNode next;
  public ListNode(int val = 0, ListNode? next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class Solution
{
  public Stack<int> ToStack(ListNode? node)
  {
    var s = new Stack<int>();
    while (node != null)
    {
      s.Push(node.val);
      node = node.next;
    }
    return s;
  }

  public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
  {
    var s1 = ToStack(l1);
    var s2 = ToStack(l2);
    var carry = 0;
    var head = new ListNode();
    while (s1.Any() || s2.Any() || carry > 0)
    {
      int sum = carry + (s1.Any() ? s1.Pop() : 0) + (s2.Any() ? s2.Pop() : 0);
      carry = sum / 10;
      // reverse the linked list
      var node = new ListNode(sum % 10);
      node.next = head.next;
      head.next = node;
    }
    return head.next;
  }
}
