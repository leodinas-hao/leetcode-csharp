/*
Shortest Path Visiting All Nodes
https://leetcode.com/problems/shortest-path-visiting-all-nodes/

You have an undirected, connected graph of n nodes labeled from 0 to n - 1. 
You are given an array graph where graph[i] is a list of all the nodes connected with node i by an edge.

Return the length of the shortest path that visits every node. You may start and stop at any node, 
you may revisit nodes multiple times, and you may reuse edges.

Example 1:
   0
  /|\
 1 2 3

Input: graph = [[1,2,3],[0],[0],[0]]
Output: 4
Explanation: One possible path is [1,0,2,0,3]

Example 2:
2---1---0
| \ |
3   4
Input: graph = [[1],[0,2,4],[1,3,4],[2],[1,2]]
Output: 4
Explanation: One possible path is [0,1,4,2,3]

Constraints:
n == graph.length
1 <= n <= 12
0 <= graph[i].length < n
graph[i] does not contain i.
If graph[a] contains b, then graph[b] contains a.
The input graph is always connected.
*/

namespace LeetCode.ShortestPathVisitingAllNodes;

/**
working backwards and DFS starting from every nodes
*/
public class Solution
{
  private int[,] cache;
  private int endingMask;

  private int DFS(int node, int mask, int[][] graph)
  {
    if (cache[node, mask] != 0) return cache[node, mask];

    if ((mask & (mask - 1)) == 0)
    {
      // mask only has a single 1, which indicates this is the first node visited
      return 0;
    }

    cache[node, mask] = Int32.MaxValue - 1;
    foreach (var neighbor in graph[node])
    {
      if ((mask & (1 << neighbor)) != 0) // neighbor node visited already
      {
        int alreadyVisited = DFS(neighbor, mask, graph);
        int notVisited = DFS(neighbor, mask ^ (1 << node), graph);
        int betterOpt = Math.Min(alreadyVisited, notVisited);
        cache[node, mask] = Math.Min(cache[node, mask], 1 + betterOpt);
      }
    }

    return cache[node, mask];
  }

  public int ShortestPathLength(int[][] graph)
  {
    int n = graph.Length;
    endingMask = (1 << n) - 1;
    cache = new int[n + 1, endingMask + 1];

    int best = Int32.MaxValue;
    for (int i = 0; i < n; i++)
    {
      // DFS start with consideration that the current node is the last 
      // after visiting all other nodes and move backwards to see how many steps to get to the 1st node
      best = Math.Min(best, DFS(i, endingMask, graph));
    }
    return best;
  }
}


/*
BFS
*/
public class Solution2
{
  public int ShortestPathLength(int[][] graph)
  {
    if (graph.Length == 1) return 0;

    int n = graph.Length;
    int endingMask = (1 << n) - 1;
    bool[,] visited = new bool[n, endingMask];
    var queue = new Queue<ValueTuple<int, int>>();

    for (int i = 0; i < n; i++)
    {
      queue.Enqueue((i, 1 << i));
      visited[i, 1 << i] = true;
    }

    int steps = 0;
    while (queue.Any())
    {
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        (int node, int mask) = queue.Dequeue();
        foreach (var neighbor in graph[node])
        {
          int nextMask = mask | (1 << neighbor);
          // visiting ending node
          if (nextMask == endingMask) return steps + 1;

          if (!visited[neighbor, nextMask])
          {
            visited[neighbor, nextMask] = true;
            queue.Enqueue((neighbor, nextMask));
          }
        }
      }
      steps++;
    }
    return -1;
  }
}