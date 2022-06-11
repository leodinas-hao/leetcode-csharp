/*
Number of Operations to Make Network Connected
https://leetcode.com/problems/number-of-operations-to-make-network-connected/

There are n computers numbered from 0 to n - 1 connected by ethernet cables connections forming a network 
where connections[i] = [ai, bi] represents a connection between computers ai and bi. Any computer can reach any other computer directly or indirectly through the network.

You are given an initial computer network connections. You can extract certain cables between two directly connected computers,
and place them between any pair of disconnected computers to make them directly connected.

Return the minimum number of times you need to do this in order to make all the computers connected. If it is not possible, return -1.

Example 1:
0--1           0--1
| /     -->    |  |
2  3           2  3

Input: n = 4, connections = [[0,1],[0,2],[1,2]]
Output: 1
Explanation: Remove cable between computer 1 and 2 and place between computers 1 and 3.

Example 2:
0---1  4          0--1--4
| X |       -->   |  |  |
2   3  5          2  3  5

Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2],[1,3]]
Output: 2

Example 3:
Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2]]
Output: -1
Explanation: There are not enough cables.

Constraints:
1 <= n <= 10^5
1 <= connections.length <= min(n * (n - 1) / 2, 10^5)
connections[i].length == 2
0 <= ai, bi < n
ai != bi
There are no repeated connections.
No two computers are connected by more than one cable.
*/

namespace LeetCode.NumberOfOperationsToMakeNetworkConnected;

public class Solution
{
  private int[] computers;

  private int Find(int node)
  {
    while (node != computers[node])
    {
      computers[node] = computers[computers[node]];
      node = computers[node];
    }
    return node;
  }

  private bool Union(int a, int b)
  {
    int x = Find(a);
    int y = Find(b);
    if (x == y) return false;

    computers[x] = y;
    return true;
  }

  public int MakeConnected(int n, int[][] connections)
  {
    // at least n-1 cables required
    if (n - 1 > connections.Length) return -1;

    computers = Enumerable.Range(0, n).ToArray();

    // perform union-find operation, if both the nodes already belong to 
    // same set, then we have to reconnect that cable
    int move = 0;
    foreach (var conn in connections)
    {
      if (!Union(conn[0], conn[1])) move++;
    }

    return move - (connections.Length - (n - 1));
  }
}