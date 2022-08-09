/*
Subtree of Another Tree
https://leetcode.com/problems/subtree-of-another-tree/

Given the roots of two binary trees root and subRoot, return true if there is a subtree of root 
with the same structure and node values of subRoot and false otherwise.

A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. 
The tree tree could also be considered as a subtree of itself.

Example 1:
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true

Example 2:
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false

Constraints:
The number of nodes in the root tree is in the range [1, 2000].
The number of nodes in the subRoot tree is in the range [1, 1000].
-10^4 <= root.val <= 10^4
-10^4 <= subRoot.val <= 10^4
*/

namespace LeetCode.SubtreeOfAnotherTree;

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
  private bool IsIdentical(TreeNode n1, TreeNode n2)
  {
    // check if tree 1 is the same as tree 2
    if (n1 == null && n2 == null) return true;
    return n1?.val == n2?.val && IsIdentical(n1.left, n2.left) && IsIdentical(n1.right, n2.right);
  }

  public bool IsSubtree(TreeNode root, TreeNode subRoot)
  {
    if (root == null) return false;
    return IsIdentical(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
  }
}
