/*
Unique Binary Search Trees
https://leetcode.com/problems/unique-binary-search-trees/

Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes of unique values from 1 to n.

Example 1:
1     |  1      |     2     |       3  |     3
 \    |   \     |    / \    |      /   |    /
  3   |    2    |   1   3   |     2    |   1
 /    |     \   |           |    /     |    \
2     |      3  |           |   1      |     2
Input: n = 3
Output: 5

Example 2:
Input: n = 1
Output: 1

Constraints:
1 <= n <= 19
*/

namespace LeetCode.UniqueBinarySearchTrees;

/*    
    n = 0;   
       null  
    
    count[0] = 1
    
    n = 1;
      1  
    
    count[1] = 1 
    

    n = 2;
         1             2     
          \           /      
       count[1]    count[1] 
    
    count[2] = 1 + 1 = 2
    
    
    n = 3;
          1                2                3
            \             / \              /  
       count[2]    count[1] count[1]   count[2]
    
    count[3] = 2 + 1 + 2  = 5
    
    
    n = 4;
          1                 2                   3                  4  
           \              /   \                / \                /   
       count[3]     count[1] count[2]    count[2] count[1]    count[3]
    
    count[4] = 5 + 2 + 2 + 5 = 14     
    

And  so on...
*/
public class Solution
{
  public int NumTrees(int n)
  {
    int[] tree = new int[n + 1];

    tree[0] = 1;
    tree[1] = 1;

    for (int i = 2; i <= n; i++)
    {
      for (int j = 1; j <= i; j++)
      {
        int left = j - 1;
        int right = i - j;
        tree[i] += tree[left] * tree[right];
      }
    }
    return tree[n];
  }
}
