/*
Path Sum III
https://leetcode.com/problems/path-sum-iii/

Given the root of a binary tree and an integer targetSum, return the number of paths where the sum of the values along the path equals targetSum.
The path does not need to start or end at the root or a leaf, but it must go downwards (i.e., traveling only from parent nodes to child nodes).

Example 1:
Input: root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
Output: 3
Explanation: The paths that sum to 8 are shown.

Example 2:
Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
Output: 3

Constraints:
The number of nodes in the tree is in the range [0, 1000].
-10^9 <= Node.val <= 10^9
-1000 <= targetSum <= 1000
*/

namespace LeetCode.PathSumIII;

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
  int count = 0;
  private void DFS(TreeNode node, long target)
  {
    if (node != null)
    {
      DFS(node.left, target);
      DFS(node.right, target);
      GetSum(node, target);
    }
  }
  private void GetSum(TreeNode node, long target)
  {
    long sum = target - node.val;
    if (sum == 0) count++;
    if (node.left != null) GetSum(node.left, sum);
    if (node.right != null) GetSum(node.right, sum);
  }
  public int PathSum(TreeNode root, int targetSum)
  {
    count = 0;
    DFS(root, targetSum);
    return count;
  }
}