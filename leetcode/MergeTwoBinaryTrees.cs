/*
merge two binary trees
https://leetcode.com/problems/merge-two-binary-trees/

You are given two binary trees root1 and root2.

Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. 
You need to merge the two trees into a new binary tree. The merge rule is that if two nodes overlap, 
then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of the new tree.
Return the merged tree.
Note: The merging process must start from the root nodes of both trees.

Example 1:
    1                  2                           3
   / \                / \                         / \
  3   2     +        1   3          ==>          4   5
 /                    \   \                     / \   \
5                      4   7                   5   4   7
Input: root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
Output: [3,4,5,5,4,null,7]

Example 2:
Input: root1 = [1], root2 = [1,2]
Output: [2,2]

Constraints:
The number of nodes in both trees is in the range [0, 2000].
-10^4 <= Node.val <= 10^4
*/

namespace LeetCode.MergeTwoBinaryTrees;

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

/*recursive*/
public class Solution
{
  public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
  {
    if (root1 == null) return root2;
    if (root2 == null) return root1;

    root1.val += root2.val;
    root1.left = MergeTrees(root1.left, root2.left);
    root1.right = MergeTrees(root1.right, root2.right);
    return root1;
  }
}

/*iterate*/
public class Solution2
{
  public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
  {
    if (root1 == null) return root2;

    Stack<(TreeNode, TreeNode)> stack = new Stack<(TreeNode, TreeNode)>();
    stack.Push((root1, root2));

    while (stack.Any())
    {
      (var n1, var n2) = stack.Pop();
      if (n2 == null) continue;
      n1.val += n2.val;
      if (n1.left == null) n1.left = n2.left;
      else stack.Push((n1.left, n2.left));
      if (n1.right == null) n1.right = n2.right;
      else stack.Push((n1.right, n2.right));
    }
    return root1;
  }
}