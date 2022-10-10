/*
Course Schedule II
https://leetcode.com/problems/course-schedule-ii/

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. 
If it is impossible to finish all courses, return an empty array.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. 
Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

Example 3:
Input: numCourses = 1, prerequisites = []
Output: [0]

Constraints:
1 <= numCourses <= 2000
0 <= prerequisites.length <= numCourses * (numCourses - 1)
prerequisites[i].length == 2
0 <= ai, bi < numCourses
ai != bi
All the pairs [ai, bi] are distinct.
*/

namespace LeetCode.CourseScheduleII;

/*
DFS
*/
public class Solution
{
  readonly int WHITE = 1; // not visited
  readonly int GRAY = 2; // in DFS checking
  readonly int BLACK = 3; // checked

  bool isPossible;
  Dictionary<int, int> color;
  Dictionary<int, IList<int>> adjList;
  IList<int> topologicalOrder;

  private void Init(int numCourses)
  {
    this.isPossible = true;
    this.color = new Dictionary<int, int>();
    this.adjList = new Dictionary<int, IList<int>>();
    this.topologicalOrder = new List<int>();

    for (int i = 0; i < numCourses; i++)
    {
      // mark all nodes are white to begin
      this.color[i] = WHITE;
      // init adjacency list
      this.adjList[i] = new List<int>();
    }
  }

  private void DFS(int node)
  {
    // stop when it's impossible
    if (!this.isPossible) return;

    // mark the node GREY as it starts recursion
    this.color[node] = GRAY;

    // check all neighbor nodes
    foreach (int neighbor in this.adjList[node])
    {
      if (this.color[neighbor] == WHITE) this.DFS(neighbor);
      else if (this.color[neighbor] == GRAY)
      {
        // an edge to a GRAY node represents a cycle 
        this.isPossible = false;
      }
    }

    // end of recursion
    this.color[node] = BLACK;
    this.topologicalOrder.Add(node);
  }

  public int[] FindOrder(int numCourses, int[][] prerequisites)
  {
    this.Init(numCourses);

    // create the adjacency list representation of the graph
    for (int i = 0; i < prerequisites.Length; i++)
    {
      int dest = prerequisites[i][0];
      int src = prerequisites[i][1];
      this.adjList[src].Add(dest);
    }

    for (int i = 0; i < numCourses; i++)
    {
      if (this.color[i] == WHITE) this.DFS(i);
    }

    if (!this.isPossible)
    {
      return new int[0];
    }

    int[] order = new int[numCourses];
    for (int i = 0; i < numCourses; i++)
    {
      order[i] = this.topologicalOrder[numCourses - i - 1];
    }
    return order;
  }
}
