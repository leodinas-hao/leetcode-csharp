/*
Kth Smallest Element in a BST
https://leetcode.com/problems/kth-smallest-element-in-a-bst/

Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

Example 1:
Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:
Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3

Constraints:
The number of nodes in the tree is n.
1 <= k <= n <= 10^4
0 <= Node.val <= 10^4

Follow up: If the BST is modified often (i.e., we can do insert and delete operations) 
and you need to find the kth smallest frequently, how would you optimize?
*/

namespace LeetCode.KthSmallestElementInABST;

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
  public int KthSmallest(TreeNode root, int k)
  {
    var stack = new Stack<TreeNode>();
    while (true)
    {
      while (root != null)
      {
        stack.Push(root);
        root = root.left;
      }
      root = stack.Pop();
      if (--k == 0) return root.val;
      root = root.right;
    }
  }
}
