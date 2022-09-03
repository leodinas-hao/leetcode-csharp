/*
Count Complete Tree Nodes
https://leetcode.com/problems/count-complete-tree-nodes

Given the root of a complete binary tree, return the number of the nodes in the tree.
According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, 
and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.
Design an algorithm that runs in less than O(n) time complexity.

Example 1:
      1
    /   \
   2     3
  / \   /
 4   5 6
Input: root = [1,2,3,4,5,6]
Output: 6

Example 2:
Input: root = []
Output: 0

Example 3:
Input: root = [1]
Output: 1

Constraints:
The number of nodes in the tree is in the range [0, 5 * 10^4].
0 <= Node.val <= 5 * 10^4
The tree is guaranteed to be complete.
*/

namespace LeetCode.CountCompleteTreeNodes;

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
  public int CountNodes(TreeNode root)
  {
    int size = 0;
    if (root == null) return 0;
    if (root.left != null)
    {
      int leftCounts = CountNodes(root.left);
      size += leftCounts;
    }
    if (root.right != null)
    {
      int rightCounts = CountNodes(root.right);
      size += rightCounts;
    }
    size++;
    return size;
  }
}

/*
BFS
*/
public class Solution2
{
  public int CountNodes(TreeNode root)
  {
    if (root == null) return 0;
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int count = 0;
    while (queue.Any())
    {
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        var node = queue.Dequeue();
        count++;
        if (node.left != null) queue.Enqueue(node.left);
        if (node.right != null) queue.Enqueue(node.right);
      }
    }
    return count;
  }
}