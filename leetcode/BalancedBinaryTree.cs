/*
Balanced Binary Tree
https://leetcode.com/problems/balanced-binary-tree/

Given a binary tree, determine if it is height-balanced.
For this problem, a height-balanced binary tree is defined as:
a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: true

Example 2:
Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Example 3:
Input: root = []
Output: true

Constraints:
The number of nodes in the tree is in the range [0, 5000].
-104 <= Node.val <= 10^4
*/

namespace LeetCode.BalancedBinaryTree;


// Definition for a binary tree node
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
  private bool balanced = true;
  // DFS checking heights of tree
  private int GetHeight(TreeNode node)
  {
    if (node == null) return 0;
    return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
  }

  public bool IsBalanced(TreeNode root)
  {
    // checking if current node is balanced
    if (root == null) return true;
    if (Math.Abs(GetHeight(root.left) - GetHeight(root.right)) > 1) balanced = false;

    // check if child nodes balanced
    IsBalanced(root.left);
    IsBalanced(root.right);
    return balanced;
  }
}


/*
instead of DFS counting the height of each node
using DFS to get height if balanced, otherwise return -1
so it's more effective than above solution
*/
public class Solution2
{
  private int Check(TreeNode node)
  {
    if (node == null) return 0;

    int left = Check(node.left);
    int right = Check(node.right);

    // try to get non-balanced return early
    if (left == -1 || right == -1) return -1;
    if (Math.Abs(left - right) > 1) return -1;

    return Math.Max(left, right) + 1;
  }

  public bool IsBalanced(TreeNode root)
  {
    return Check(root) != -1;
  }
}