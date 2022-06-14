/*
Reorder Routes to Make All Paths Lead to the City Zero
https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/

There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel 
between two different cities (this network form a tree). Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.
Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to city bi.
This year, there will be a big event in the capital (city 0), and many people want to travel to this city.
Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.
It's guaranteed that each city can reach city 0 after reorder.

Example 1:
2 --> 3 <-x- 1 <-x- 0 <-- 4 -x-> 5      after      2 --> 3 --> 1 --> 0 <-- 4 <-- 5

Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 2:
0 <-- 1 -x-> 2 <-- 3 -x-> 4         after          0 <-- 1 <-- 2 <-- 3 <-- 4

Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
Output: 2
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 3:
1 --> 0 <-- 2

Input: n = 3, connections = [[1,0],[2,0]]
Output: 0

Constraints:
2 <= n <= 5 * 10^4
connections.length == n - 1
connections[i].length == 2
0 <= ai, bi <= n - 1
ai != bi
*/

namespace LeetCode.ReorderRoutesToMakeAllPathsLeadToTheCityZero;

public class Solution
{
  public int MinReorder(int n, int[][] connections)
  {
    // build a connection list of each node
    // graph[i] is a list of all connections that start from the node i
    // the connection is a tuple of (dest node, forward)
    // where forward is true, if it's existing direction/going forward; 
    // otherwise (alternating required) is false
    var graph = new List<IList<ValueTuple<int, bool>>>();
    for (int i = 0; i < n; i++)
    {
      graph.Add(new List<ValueTuple<int, bool>>());
    }
    foreach (var conn in connections)
    {
      int src = conn[0], dest = conn[1];
      graph[src].Add((dest, true));
      graph[dest].Add((src, false));
    }

    // BFS
    var queue = new Queue<int>();
    queue.Enqueue(0);
    var visited = new bool[n];
    visited[0] = true;
    int changes = 0;

    while (queue.Any())
    {
      int node = queue.Dequeue();
      foreach ((int dest, bool forward) in graph[node])
      {
        if (!visited[dest])
        {
          queue.Enqueue(dest);
          visited[dest] = true;
          // as starting from 0 and looking for direction going backwards
          // when the direction is moving forward, need to alternate the direction, so +1 change
          if (forward) changes += 1;
        }
      }
    }

    return changes;
  }
}


// this solution gets "Time Limit Exceeded" error
// suspect due to the large matrix, where the input n is 7300
public class Solution2
{
  private int DFS(int[][] graph, int node, bool[] visited)
  {
    int changes = 0;
    visited[node] = true;

    for (int i = 0; i < graph.Length; i++)
    {
      if (i != node && !visited[i] && graph[i][node] >= 0)
      {
        changes += graph[i][node];
        changes += DFS(graph, i, visited);
      }
    }
    return changes;
  }

  public int MinReorder(int n, int[][] connections)
  {
    // build a n*n matrix as the graph to represent the nodes & the connections (with direction)
    // "graph[i][j] = val", indicating connection form i to j
    // when there is an existing path, "val" is 0
    // when there is path (need to alternate direction), "val" is 1
    // when no path exists, "val" is -1
    var graph = new int[n][];
    for (int i = 0; i < n; i++)
    {
      graph[i] = new int[n];
      Array.Fill(graph[i], -1);
    }

    // add connections to graph
    foreach (var conn in connections)
    {
      int src = conn[0], dest = conn[1];
      graph[src][dest] = 0; // existing path without changing direction
      graph[dest][src] = 1; // existing path but need to change direction
    }

    return DFS(graph, 0, new bool[n]);
  }
}
