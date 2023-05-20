/*
Evaluate Division
https://leetcode.com/problems/evaluate-division/

You are given an array of variable pairs equations and an array of real numbers values, 
where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. 
Each Ai or Bi is a string that represents a single variable.

You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.
Return the answers to all queries. If a single answer cannot be determined, return -1.0.

Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.


Example 1:
Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
Explanation: 
Given: a / b = 2.0, b / c = 3.0
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
return: [6.0, 0.5, -1.0, 1.0, -1.0]

Example 2:
Input: equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0], queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
Output: [3.75000,0.40000,5.00000,0.20000]

Example 3:
Input: equations = [["a","b"]], values = [0.5], queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
Output: [0.50000,2.00000,-1.00000,-1.00000]

Constraints:
1 <= equations.length <= 20
equations[i].length == 2
1 <= Ai.length, Bi.length <= 5
values.length == equations.length
0.0 < values[i] <= 20.0
1 <= queries.length <= 20
queries[i].length == 2
1 <= Cj.length, Dj.length <= 5
Ai, Bi, Cj, Dj consist of lower case English letters and digits.
*/


namespace LeetCode.EvaluateDivision;

public class Solution
{
  // graph like { dividend: { divisor: value } }
  private Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
  private HashSet<string> visited = new HashSet<string>();

  public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
  {
    var ans = new double[queries.Count];

    // build the equations graph like { dividend: { divisor: value } }
    for (int i = 0; i < values.Length; i++)
    {
      string a = equations[i][0], b = equations[i][1];
      double v = values[i], v1 = 1 / v;

      if (graph.ContainsKey(a)) graph[a][b] = v;
      else graph[a] = new Dictionary<string, double>() { { b, v } };
      if (graph.ContainsKey(b)) graph[b][a] = v1;
      else graph[b] = new Dictionary<string, double>() { { a, v1 } };
    }

    for (int i = 0; i < queries.Count; i++)
    {
      visited.Clear();
      ans[i] = DFS(queries[i][0], queries[i][1], 1.0);
    }

    return ans;
  }

  private double DFS(string source, string target, double num)
  {
    if (!graph.ContainsKey(source)) return -1.0;
    if (source == target) return num;

    visited.Add(source);

    foreach (var eq in graph[source])
    {
      if (!visited.Contains(eq.Key))
      {
        var ans = DFS(eq.Key, target, eq.Value);
        if (ans != -1) return num * ans;
      }
    }

    return -1.0;
  }
}
