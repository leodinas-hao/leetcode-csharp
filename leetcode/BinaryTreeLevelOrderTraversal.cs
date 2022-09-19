/*
Binary Tree Level Order Traversal
https://leetcode.com/problems/binary-tree-level-order-traversal/

Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Example 1:
      3
     / \
    9   20
        / \
       15  7
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]
Example 2:

Input: root = [1]
Output: [[1]]

Example 3:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 2000].
-1000 <= Node.val <= 1000
*/

namespace LeetCode.BinaryTreeLevelOrderTraversal;

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
  public IList<IList<int>> LevelOrder(TreeNode root)
  {
    var ans = new List<IList<int>>();
    if (root != null)
    {
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Any())
      {
        var n = queue.Count;
        var row = new List<int>();
        for (int i = 0; i < n; i++)
        {
          var node = queue.Dequeue();
          row.Add(node.val);
          if (node.left != null) queue.Enqueue(node.left);
          if (node.right != null) queue.Enqueue(node.right);
        }
        ans.Add(row);
      }
    }

    return ans;
  }
}
