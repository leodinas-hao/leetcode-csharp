/*
Linked List in Binary Tree
https://leetcode.com/problems/linked-list-in-binary-tree/

Given a binary tree root and a linked list with head as the first node. 
Return True if all the elements in the linked list starting from the head correspond to some downward path connected in the binary tree otherwise return False.
In this context downward path means a path that starts at some node and goes downwards.

Example 1:
        1
       / \
      4   (4)
       \   /
        2 (2)
       /  / \
      1  6  (8)
            / \
           1   3
Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
Explanation: Nodes in brackets form a subpath in the binary Tree.  

Example 2:
       (1)
      /   \
     4    (4) 
      \    / 
       2  (2) 
      /   / \   
     1  (6)  8
            / \
           1   3
Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true

Example 3:
Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: false
Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.

Constraints:
The number of nodes in the tree will be in the range [1, 2500].
The number of nodes in the list will be in the range [1, 100].
1 <= Node.val <= 100 for each node in the linked list and binary tree.
*/

namespace LeetCode.LinkedListInBinaryTree;

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

/**
 * Definition for a binary tree node.
 */
public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
  {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}

public class Solution
{
  private bool Check(ListNode head, TreeNode root)
  {
    // reach to the end of the linked list, return true
    if (head == null) return true;
    // reach to the end of the binary tree, return false
    if (root == null) return false;

    if (head.val != root.val) return false;
    // find the match, move to next list & tree node
    return Check(head.next, root.left) || Check(head.next, root.right);
  }

  public bool IsSubPath(ListNode head, TreeNode root)
  {
    if (head == null) return true;
    if (root == null) return false;
    if (Check(head, root)) return true;
    // call `IsSubPath` to keep the reference of the head for the next iteration
    return IsSubPath(head, root.left) || IsSubPath(head, root.right);
  }
}
