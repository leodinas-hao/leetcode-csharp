/*
Populating Next Right Pointers in Each Node II
https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/

Given a binary tree

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
Initially, all next pointers are set to NULL.

Example 1:
    1                    1->#
   / \                  / \
  2   3       ==>      2-> 3->#
 / \   \              / \   \
4   5   7            4-> 5-> 7->#

Input: root = [1,2,3,4,5,null,7]
Output: [1,#,2,3,#,4,5,7,#]
Explanation: Given the above binary tree (Figure A), your function should populate each next pointer to point to its next right node, 
just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

Example 2:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 6000].
-100 <= Node.val <= 100

Follow-up:
You may only use constant extra space.
The recursive approach is fine. You may assume implicit stack space does not count as extra space for this problem.
*/

namespace LeetCode.PopulatingNextRightPointersInEachNodeII;


// Definition for a Node.
public class Node
{
  public int val; public Node left;
  public Node right;
  public Node next;

  public Node() { }

  public Node(int _val)
  {
    val = _val;
  }

  public Node(int _val, Node _left, Node _right, Node _next)
  {
    val = _val;
    left = _left;
    right = _right;
    next = _next;
  }
}

public class Solution
{
  private Node GetNextRightChild(Node node)
  {
    // keep moving to the next node to find the next right child
    while (node != null && node.left == null && node.right == null)
    {
      node = node?.next;
    }
    if (node == null) return null;

    if (node.left != null) return node.left;
    else return node.right;
  }

  public Node Connect(Node root)
  {
    if (root == null) return root;
    var queue = new Queue<Node>();
    queue.Enqueue(root);
    while (queue.Any())
    {
      var node = queue.Dequeue();

      // add `next` of `node` left child
      if (node.left != null)
      {
        if (node.right != null) node.left.next = node.right;
        else node.left.next = GetNextRightChild(node.next);
        queue.Enqueue(node.left);
      }
      // add `next` of `node` right child
      if (node.right != null)
      {
        node.right.next = GetNextRightChild(node.next);
        queue.Enqueue(node.right);
      }
    }
    return root;
  }
}