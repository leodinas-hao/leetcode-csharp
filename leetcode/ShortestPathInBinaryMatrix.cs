/*
Shortest path in binary matrix
https://leetcode.com/problems/shortest-path-in-binary-matrix/

Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.

A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
All the visited cells of the path are 0.
All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
The length of a clear path is the number of visited cells of this path.

Example 1:
0 1
 \
1 0
Input: grid = [[0,1],[1,0]]
Output: 2

Example 2:
0-0 0
   \
1 1 0
    |
1 1 0
Input: grid = [[0,0,0],[1,1,0],[1,1,0]]
Output: 4

Example 3:
1 0 0
1 1 0
1 1 0
Input: grid = [[1,0,0],[1,1,0],[1,1,0]]
Output: -1

Constraints:
n == grid.length
n == grid[i].length
1 <= n <= 100
grid[i][j] is 0 or 1
*/

namespace LeetCode.ShortestPathInBinaryMatrix;

public class Solution
{
  public int ShortestPathBinaryMatrix(int[][] grid)
  {
    int n = grid.Length;  // get size of the grid
    // edge case where the beginning/end cell is not 0
    if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0) return -1;

    // 8 directions in the order of best ones come first
    ValueTuple<int, int>[] dirs = {
      (1, 1),  // down right
      (1, 0),  // down
      (0, 1),  // right
      (-1, 1),  // up right
      (1, -1),  // left
      (-1, 0),  // up
      (0, -1),  // left
      (-1, -1)  // up left
    };

    // BFS to find the clear path
    // queue the steps (r, c, steps)
    var queue = new Queue<ValueTuple<int, int, int>>();
    // 1st step starts from (0, 0, 1)
    queue.Enqueue((0, 0, 1));
    int r, c, s;
    while (queue.Any())
    {
      (r, c, s) = queue.Dequeue();
      if (r == n - 1 && c == n - 1) return s;

      foreach (var d in dirs)
      {
        int rNext = r + d.Item1;
        int cNext = c + d.Item2;
        if (rNext >= 0 && cNext >= 0 && rNext < n && cNext < n && grid[rNext][cNext] == 0)
        {
          queue.Enqueue((rNext, cNext, s + 1));
          grid[rNext][cNext] = 1;  // mark it to 1 to avoid revisit
        }
      }
    }
    return -1;
  }
}