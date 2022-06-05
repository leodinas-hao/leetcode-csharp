/*
Convert Binary Number in a Linked List to Integer
https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/

Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. 
The linked list holds the binary representation of a number.

Return the decimal value of the number in the linked list.

Example 1:
1 -> 0 ->
Input: head = [1,0,1]
Output: 5
Explanation: (101) in base 2 = (5) in base 10

Example 2:
Input: head = [0]
Output: 0

Constraints:
The Linked List is not empty.
Number of nodes will not exceed 30.
Each node's value is either 0 or 1.
*/

namespace LeetCode.ConvertBinaryNumberInALinkedListToInteger;

public class ListNode
{
  public int val;
  public ListNode? next;
  public ListNode(int val = 0, ListNode? next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class Solution
{
  public int GetDecimalValue(ListNode head)
  {
    int num = head.val;
    while (head.next != null)
    {
      num = num * 2 + head.next.val;
      head = head.next;
    }
    return num;
  }
}