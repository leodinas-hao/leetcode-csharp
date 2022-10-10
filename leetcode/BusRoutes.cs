/*
bus routes
https://leetcode.com/problems/bus-routes/

You are given an array routes representing bus routes where routes[i] is a bus route that the ith bus repeats forever.
For example, if routes[0] = [1, 5, 7], this means that the 0th bus travels 
in the sequence 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... forever.
You will start at the bus stop source (You are not on any bus initially), 
and you want to go to the bus stop target. You can travel between bus stops by buses only.
Return the least number of buses you must take to travel from source to target. Return -1 if it is not possible.

Example 1:
Input: routes = [[1,2,7],[3,6,7]], source = 1, target = 6
Output: 2
Explanation: The best strategy is take the first bus to the bus stop 7, then take the second bus to the bus stop 6.

Example 2:
Input: routes = [[7,12],[4,5,15],[6],[15,19],[9,12,13]], source = 15, target = 12
Output: -1

Constraints:
1 <= routes.length <= 500.
1 <= routes[i].length <= 10^5
All the values of routes[i] are unique.
sum(routes[i].length) <= 10^5
0 <= routes[i][j] < 10^6
0 <= source, target < 10^6
*/

namespace LeetCode.BusRoutes;

/*
BFS
*/
public class Solution
{
  private bool Intersect(int[] a, int[] b)
  {
    int i = 0, j = 0;
    while (i < a.Length && j < b.Length)
    {
      if (a[i] == b[j]) return true;
      if (a[i] < b[j]) i++;
      else j++;
    }
    return false;
  }

  public int NumBusesToDestination(int[][] routes, int source, int target)
  {
    if (source == target) return 0;
    int n = routes.Length;
    var graph = new List<IList<int>>();
    for (int i = 0; i < n; i++)
    {
      Array.Sort(routes[i]);
      graph.Add(new List<int>());
    }
    var seen = new HashSet<int>();
    var targets = new HashSet<int>();
    var queue = new Queue<(int, int)>();

    // build the graph
    // two buses connected if they share at least one bus stop
    for (int i = 0; i < n; i++)
    {
      for (int j = i + 1; j < n; j++)
      {
        if (Intersect(routes[i], routes[j]))
        {
          graph[i].Add(j);
          graph[j].Add(i);
        }
      }
    }

    for (int i = 0; i < n; i++)
    {
      if (Array.BinarySearch(routes[i], source) >= 0)
      {
        seen.Add(i);
        queue.Enqueue((i, 0));
      }
      if (Array.BinarySearch(routes[i], target) >= 0)
      {
        targets.Add(i);
      }
    }

    while (queue.Any())
    {
      (int node, int depth) = queue.Dequeue();
      if (targets.Contains(node)) return depth + 1;
      foreach (int neighbor in graph[node])
      {
        if (!seen.Contains(neighbor))
        {
          seen.Add(neighbor);
          queue.Enqueue((neighbor, depth + 1));
        }
      }
    }

    return -1;
  }
}
