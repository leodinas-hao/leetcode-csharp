/*
Rotting Oranges
https://leetcode.com/problems/rotting-oranges/

You are given an m x n grid where each cell can have one of three values:

0 representing an empty cell,
1 representing a fresh orange, or
2 representing a rotten orange.
Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

Example 1:
 2 1 1      2 2 1      2 2 2      2 2 2      2 2 2
 1 1 0  ->  2 1 0  ->  2 2 0  ->  2 2 0  ->  2 2 0
 0 1 1      0 1 1      0 1 1      0 2 1      0 2 2

Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
Output: 4

Example 2:
Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
Output: -1
Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.

Example 3:
Input: grid = [[0,2]]
Output: 0
Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 10
grid[i][j] is 0, 1, or 2.
*/

namespace LeetCode.RottingOranges;

public class Solution
{
  public int OrangesRotting(int[][] grid)
  {
    int rows = grid.Length, cols = grid[0].Length;
    if (rows == 0 || cols == 0) return -1;

    int freshOranges = 0, minutes = 0;
    // put all rotten cell position into queue for BFS
    var queue = new Queue<(int, int)>();
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        if (grid[i][j] == 1) freshOranges++;
        else if (grid[i][j] == 2) queue.Enqueue((i, j));
      }
    }

    ValueTuple<int, int>[] directions = new ValueTuple<int, int>[]{
      (-1, 0),
      (1, 0),
      (0, -1),
      (0, 1)
    };

    // no fresh orange
    if (freshOranges == 0) return 0;

    while (queue.Any())
    {
      if (freshOranges == 0) return minutes;
      int size = queue.Count;
      for (int q = 0; q < size; q++)
      {
        (var i, var j) = queue.Dequeue();
        // check 4 directions
        foreach ((var r, var c) in directions)
        {
          int i2 = i + r, j2 = j + c;
          if (i2 >= 0 && i2 < rows && j2 >= 0 && j2 < cols)
          {
            // find a fresh orange
            if (grid[i2][j2] == 1)
            {
              freshOranges--;
              grid[i2][j2] = 2;
              queue.Enqueue((i2, j2));
            }
          }
        }
      }
      minutes++;
    }
    // impossible
    return -1;
  }
}