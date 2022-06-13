/*
Shortest Path with Alternating Colors
https://leetcode.com/problems/shortest-path-with-alternating-colors/

You are given an integer n, the number of nodes in a directed graph where the nodes are labeled from 0 to n - 1. 
Each edge is red or blue in this graph, and there could be self-edges and parallel edges.
You are given two arrays redEdges and blueEdges where:
redEdges[i] = [ai, bi] indicates that there is a directed red edge from node ai to node bi in the graph, and
blueEdges[j] = [uj, vj] indicates that there is a directed blue edge from node uj to node vj in the graph.
Return an array answer of length n, where each answer[x] is the length of the shortest path from node 0 to node x
such that the edge colors alternate along the path, or -1 if such a path does not exist.

Example 1:
Input: n = 3, redEdges = [[0,1],[1,2]], blueEdges = []
Output: [0,1,-1]

Example 2:
Input: n = 3, redEdges = [[0,1]], blueEdges = [[2,1]]
Output: [0,1,-1]

Constraints:
1 <= n <= 100
0 <= redEdges.length, blueEdges.length <= 400
redEdges[i].length == blueEdges[j].length == 2
0 <= ai, bi, uj, vj < n
*/

namespace LeetCode.ShortestPathWithAlternatingColors;

public class Solution
{
  // RED: 1, BLUE: -1, when both color edges exist, mark 0
  public const int RED = 1;
  public const int BLUE = -1;

  private int[][] BuildGraph(int n, int[][] redEdges, int[][] blueEdges)
  {
    // build the graph as a n*n matrix
    // graph[i][j] = color 
    // i is the starting node, j is destination node, the value is the color
    int[][] graph = new int[n][];
    for (int i = 0; i < n; i++)
    {
      graph[i] = new int[n];
      Array.Fill(graph[i], Int32.MaxValue);
    }

    // add color edges
    foreach (var e in redEdges)
    {
      graph[e[0]][e[1]] = RED;
    }
    foreach (var e in blueEdges)
    {
      graph[e[0]][e[1]] = graph[e[0]][e[1]] == RED ? 0 : BLUE;
    }
    return graph;
  }

  public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
  {
    var graph = BuildGraph(n, redEdges, blueEdges);

    int[] paths = new int[n];
    Array.Fill(paths, Int32.MaxValue);

    Queue<ValueTuple<int, int>> queue = new Queue<(int, int)>();
    // starting BFS by searching both color at 0 node
    queue.Enqueue((0, RED));
    queue.Enqueue((0, BLUE));
    paths[0] = 0;

    // track what's visited as (dest, color)
    HashSet<ValueTuple<int, int>> visited = new HashSet<(int, int)>();

    int steps = 0; // track current steps/paths
    while (queue.Any())
    {
      int size = queue.Count;
      steps++;
      for (int i = 0; i < size; i++)
      {
        (int node, int color) = queue.Dequeue();
        int opColor = -color;

        for (int j = 1; j < n; j++)
        {
          if (graph[node][j] == opColor || graph[node][j] == 0)
          {
            if (visited.Add((j, opColor)))
            {
              queue.Enqueue((j, opColor));
              paths[j] = Math.Min(paths[j], steps);
            }
          }
        }
      }
    }

    // fix the unreachable paths
    for (int i = 1; i < n; i++)
    {
      if (paths[i] == Int32.MaxValue) paths[i] = -1;
    }

    return paths;
  }
}