/*
Range Sum of BST
https://leetcode.com/problems/range-sum-of-bst/

Given the root node of a binary search tree and two integers low and high, 
return the sum of values of all nodes with a value in the inclusive range [low, high].

Example 1:
            10
           /  \
          5    15
         / \    \
        3   7   18 
Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
Output: 32
Explanation: Nodes 7, 10, and 15 are in the range [7, 15]. 7 + 10 + 15 = 32.

Example 2:
             10
           /   \
          5    15
         / \  /  \
        3   7 13  18
       /    /
      1    6
Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
Output: 23
Explanation: Nodes 6, 7, and 10 are in the range [6, 10]. 6 + 7 + 10 = 23.
 

Constraints:
The number of nodes in the tree is in the range [1, 2 * 10^4].
1 <= Node.val <= 10^5
1 <= low <= high <= 10^5
All Node.val are unique.

*/

namespace LeetCode.RangeSumOfBST;

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

// DFS the whole tree & sum the qualified values
public class Solution
{
  public int RangeSumBST(TreeNode root, int low, int high)
  {
    int sum = 0;
    if (root == null) return sum;
    if (root.val >= low && root.val <= high) sum += root.val;
    sum = sum + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
    return sum;
  }
}
