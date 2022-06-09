/*
Shortest Bridge
https://leetcode.com/problems/shortest-bridge/

You are given an n x n binary matrix grid where 1 represents land and 0 represents water.
An island is a 4-directionally connected group of 1's not connected to any other 1's. 
There are exactly two islands in grid.
You may change 0's to 1's to connect the two islands to form one island.
Return the smallest number of 0's you must flip to connect the two islands.

Example 1:
0 1     0 1
1 0 --> 1 1
Input: grid = [[0,1],[1,0]]
Output: 1

Example 2:
0 1 0       0 1 0
0 0 0  -->  0 1 0
0 0 1       0 1 1
Input: grid = [[0,1,0],[0,0,0],[0,0,1]]
Output: 2

Example 3:
1 1 1 1 1         1 1 1 1 1
1 0 0 0 1         1 0 0 0 1
1 0 1 0 1   -->   1 1 1 0 1
1 0 0 0 1         1 0 0 0 1
1 1 1 1 1         1 1 1 1 1
Input: grid = [[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
Output: 1

Constraints:
n == grid.length == grid[i].length
2 <= n <= 100
grid[i][j] is either 0 or 1.
There are exactly two islands in grid.
*/

namespace LeetCode.ShortestBridge;

public class Solution
{
  // all possible movements of 4 directions
  private int[][] movements = {
    new int[]{ 0, 1 },
    new int[]{ 0, -1 },
    new int[]{ -1, 0 },
    new int[]{ 1, 0 }
  };

  // check if given position is valid
  private bool IsValid(int[][] grid, int r, int c)
  {
    return r >= 0 && c >= 0 && r < grid.Length && c < grid[0].Length;
  }

  // DFS to find island cells
  private void DFS(int[][] grid, Queue<ValueTuple<int, int>> queue, int r, int c)
  {
    if (!IsValid(grid, r, c) || grid[r][c] == 0 || grid[r][c] == 2)
    {
      return;
    }
    // mark the 1st island cells to 2
    grid[r][c] = 2;
    queue.Enqueue((r, c));
    foreach (var m in movements)
    {
      DFS(grid, queue, r + m[0], c + m[1]);
    }
  }

  public int ShortestBridge(int[][] grid)
  {
    bool found = false;
    int steps = 0;
    var queue = new Queue<ValueTuple<int, int>>();

    // DFS find first island and mark all cells to 2
    // add the island cells into queue for BFS later
    for (int i = 0; i < grid.Length; i++)
    {
      for (int j = 0; j < grid[0].Length; j++)
      {
        if (grid[i][j] == 1 && !found)
        {
          // stop search further to avoid touching the 2nd island
          found = true;
          DFS(grid, queue, i, j);
        }
      }
    }

    // BFS from all cells in first island
    while (queue.Any())
    {
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        (int r, int c) = queue.Dequeue();
        foreach (var m in movements)
        {
          int r2 = r + m[0], c2 = c + m[1];
          if (IsValid(grid, r2, c2))
          {
            if (grid[r2][c2] == 1)
            {
              // meet a cell of 2nd island
              // this is the shortest steps
              return steps;
            }
            else if (grid[r2][c2] == 0)
            {
              // water cells, mark as 2 and add to queue
              grid[r2][c2] = 2;
              queue.Enqueue((r2, c2));
            }

          }
        }
      }
      // increase a step
      steps++;
    }

    // final catch if no return
    // this should not happen if given valid inputs
    return -1;
  }
}