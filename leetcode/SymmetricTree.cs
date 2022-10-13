/*
Symmetric Tree
https://leetcode.com/problems/symmetric-tree/
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

Example 1:
      1     
    / | \
   2  |  2
  / \ | / \
 3   4|4   3
Input: root = [1,2,2,3,4,4,3]
Output: true

Example 2:
    1
   / \
  2   2
   \   \
    3   3
Input: root = [1,2,2,null,3,null,3]
Output: false

Constraints:
The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
*/

namespace LeetCode.SymmetricTree;

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
  private bool IsMirror(TreeNode n1, TreeNode n2)
  {
    if (n1 == null && n2 == null) return true;
    if (n1 == null || n2 == null) return false;
    if (n1.val != n2.val) return false;
    return IsMirror(n1.left, n2.right) && IsMirror(n1.right, n2.left);
  }
  public bool IsSymmetric(TreeNode root)
  {
    return root == null || IsMirror(root.left, root.right);
  }
}