/*
Minimum Depth of Binary Tree
https://leetcode.com/problems/minimum-depth-of-binary-tree/

Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

Note: A leaf is a node with no children.


Example 1:
   3
  / \
 9  20
    / \
   15  7
Input: root = [3,9,20,null,null,15,7]
Output: 2

Example 2:
  2
   \
    3
     \
      4
       \
        5
         \
          6
Input: root = [2,null,3,null,4,null,5,null,6]
Output: 5

Constraints:
The number of nodes in the tree is in the range [0, 105].
-1000 <= Node.val <= 1000
*/

namespace LeetCode.MinimumDepthOfBinaryTree;

// Definition for a binary tree node.
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
  // BFS
  public int MinDepth(TreeNode root)
  {
    if (root == null) return 0;

    int depth = 0;
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Any())
    {
      depth++;
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        var node = queue.Dequeue();
        if (node.left == null && node.right == null) return depth;
        if (node.left != null) queue.Enqueue(node.left);
        if (node.right != null) queue.Enqueue(node.right);
      }
    }

    return depth;
  }
}


public class Solution2
{
  // DFS
  public int MinDepth(TreeNode root)
  {
    if (root == null) return 0;
    if (root.left != null && root.right != null)
    {
      return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
    }
    else
    {
      return 1 + MinDepth(root.right != null ? root.right : root.left);
    }
  }
}
