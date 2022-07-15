/*
Perfect Squares
https://leetcode.com/problems/perfect-squares/

Given an integer n, return the least number of perfect square numbers that sum to n.
A perfect square is an integer that is the square of an integer; 
in other words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.

Example 1:
Input: n = 12
Output: 3
Explanation: 12 = 4 + 4 + 4.

Example 2:
Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.

Constraints:
1 <= n <= 10^4
*/

namespace LeetCode.PerfectSquares;

// DP
public class Solution
{
  public int NumSquares(int n)
  {
    var dp = new int[n + 1];

    for (int i = 1; i <= n; i++)
    {
      int count = Int32.MaxValue;
      for (int j = 1; j * j <= i; j++)
      {
        count = Math.Min(count, dp[i - j * j]);
      }
      dp[i] = 1 + count;
    }

    return dp[n];
  }
}

// DP
public class Solution2
{
  public int NumSquares(int n)
  {
    var dp = new int[n + 1];
    Array.Fill(dp, Int32.MaxValue);
    dp[0] = 0;
    dp[1] = 1; // 1

    for (int i = 1; i <= n; i++)
    {
      for (int j = 1; j * j <= i; j++)
      {
        dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
      }
    }

    return dp[n];
  }
}

/* 
BFS
starting from node "n", each time we move from current node to currentNode - perfectSquares until reaching node 0
in another word, it's the minimum distance from n to 0
*/
public class Solution3
{
  public int NumSquares(int n)
  {
    var queue = new Queue<int>();
    queue.Enqueue(n);
    var visited = new HashSet<int>();
    visited.Add(n);
    int count = 0;

    while (queue.Any())
    {
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        int node = queue.Dequeue();

        if (node == 0) return count;

        for (int j = 1; j < node; j++)
        {
          int sqr = j * j;
          int next = node - sqr;
          if (next < 0) break; // stop here as following nodes are unreachable
          // add next step
          if (visited.Add(next)) queue.Enqueue(next);
        }
      }
      count++;
    }

    return count;
  }
}