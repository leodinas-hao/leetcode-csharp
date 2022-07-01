/*
All Paths From Source to Target
https://leetcode.com/problems/all-paths-from-source-to-target/

Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths from node 0 to node n - 1 and return them in any order.
The graph is given as follows: graph[i] is a list of all nodes you can visit from node i (i.e., there is a directed edge from node i to node graph[i][j]).

Example 1:
0 -> 1
|    |
2 -> 3

Input: graph = [[1,2],[3],[3],[]]
Output: [[0,1,3],[0,2,3]]
Explanation: There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.

Example 2:
Input: graph = [[4,3,1],[3,2,4],[3],[4],[]]
Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]

Constraints:
n == graph.length
2 <= n <= 15
0 <= graph[i][j] < n
graph[i][j] != i (i.e., there will be no self-loops).
All the elements of graph[i] are unique.
The input graph is guaranteed to be a DAG.
*/

namespace LeetCode.AllPathsFromSourceToTarget;

public class Solution
{

  public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
  {
    var paths = new List<IList<int>>();

    void dfs(int curr, int[] path)
    {
      if (curr == graph.Length - 1)
      {
        paths.Add(path);
        return;
      }
      foreach (var nei in graph[curr])
      {
        var clone = new int[path.Length + 1];
        Array.Copy(path, clone, path.Length);
        clone[path.Length] = nei;
        dfs(nei, clone);
      }
    };

    dfs(0, new int[] { 0 });

    return paths;
  }
}


/*
DFS
*/
public class Solution2
{
  private void Helper(int[][] graph, int i, int[] path, IList<IList<int>> paths)
  {
    if (i == graph.Length - 1)
    {
      paths.Add(path);
      return;
    }
    foreach (var nei in graph[i])
    {
      var clone = new int[path.Length + 1];
      Array.Copy(path, clone, path.Length);
      clone[path.Length] = nei;
      Helper(graph, nei, clone, paths);
    }
  }

  public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
  {
    var paths = new List<IList<int>>();
    Helper(graph, 0, new int[] { 0 }, paths);
    return paths;
  }
}