/*
Swap nodes in pairs
https://leetcode.com/problems/swap-nodes-in-pairs/

Given a linked list, swap every two adjacent nodes and return its head. 
You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

Example 1:
1->2->3->4     ====> 2->1->4->3
Input: head = [1,2,3,4]
Output: [2,1,4,3]

Example 2:
Input: head = []
Output: []

Example 3:
Input: head = [1]
Output: [1]
 
Constraints:
The number of nodes in the list is in the range [0, 100].
0 <= Node.val <= 100
*/

namespace LeetCode.SwapNodesInPairs;

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

/*
recursion
*/
public class Solution
{
  public ListNode SwapPairs(ListNode head)
  {
    if (head == null || head.next == null) return head;

    var temp = head;
    head = head.next; // swap head with next node
    temp.next = SwapPairs(head.next);
    head.next = temp; // update the next node of the new head

    return head;
  }
}

/*
iteration (change the value of the nodes instead of swapping nodes)
*/
public class Solution2
{
  public ListNode SwapPairs(ListNode head)
  {
    if (head == null) return head;

    var temp = head;
    while (temp.next != null)
    {
      // change node values
      int val = temp.val;
      temp.val = temp.next.val;
      temp.next.val = val;
      // move to next pair
      temp = temp.next.next;
      // break loop if reaching to the end
      if (temp == null) break;
    }
    return head;
  }
}
