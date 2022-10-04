/*
Invert Binary Tree
https://leetcode.com/problems/invert-binary-tree/

Given the root of a binary tree, invert the tree, and return its root.

Example 1:
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
  2           2
 / \    to   / \
1   3       3   1
Input: root = [2,1,3]
Output: [2,3,1]

Example 3:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
*/

namespace LeetCode.InvertBinaryTree;

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
  private void Swap(TreeNode node)
  {
    if (node == null) return;
    var temp = node.right;
    node.right = node.left;
    node.left = temp;

    if (node.left != null) Swap(node.left);
    if (node.right != null) Swap(node.right);
  }

  public TreeNode InvertTree(TreeNode root)
  {
    Swap(root);
    return root;
  }
}