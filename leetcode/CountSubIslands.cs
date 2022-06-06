/*
Count sub islands
https://leetcode.com/problems/count-sub-islands/

You are given two m x n binary matrices grid1 and grid2 containing only 0's (representing water) and 1's (representing land). 
An island is a group of 1's connected 4-directionally (horizontal or vertical). Any cells outside of the grid are considered water cells.
An island in grid2 is considered a sub-island if there is an island in grid1 that contains all the cells that make up this island in grid2.
Return the number of islands in grid2 that are considered sub-islands.

Example 1:
[1,1,1,0,0],    ->    [1,1,1,0,0],
[0,1,1,1,1],    ->    [0,0,1,1,1],
[0,0,0,0,0],    ->    [0,1,0,0,0],
[1,0,0,0,0],    ->    [1,0,1,1,0],
[1,1,0,1,1],    ->    [0,1,0,1,0],

Input: grid1 = [[1,1,1,0,0],[0,1,1,1,1],[0,0,0,0,0],[1,0,0,0,0],[1,1,0,1,1]], grid2 = [[1,1,1,0,0],[0,0,1,1,1],[0,1,0,0,0],[1,0,1,1,0],[0,1,0,1,0]]
Output: 3
Explanation: In the picture above, the grid on the left is grid1 and the grid on the right is grid2.
The 1s colored red in grid2 are those considered to be part of a sub-island. There are three sub-islands.

Example 2:
[1,0,1,0,1],    ->     [0,0,0,0,0],
[1,1,1,1,1],    ->     [1,1,1,1,1],
[0,0,0,0,0],    ->     [0,1,0,1,0],
[1,1,1,1,1],    ->     [0,1,0,1,0],
[1,0,1,0,1],    ->     [1,0,0,0,1],

Input: grid1 = [[1,0,1,0,1],[1,1,1,1,1],[0,0,0,0,0],[1,1,1,1,1],[1,0,1,0,1]], grid2 = [[0,0,0,0,0],[1,1,1,1,1],[0,1,0,1,0],[0,1,0,1,0],[1,0,0,0,1]]
Output: 2 
Explanation: In the picture above, the grid on the left is grid1 and the grid on the right is grid2.
The 1s colored red in grid2 are those considered to be part of a sub-island. There are two sub-islands.

Constraints:
m == grid1.length == grid2.length
n == grid1[i].length == grid2[i].length
1 <= m, n <= 500
grid1[i][j] and grid2[i][j] are either 0 or 1
*/

namespace LeetCode.CountSubIslands;

public class Solution
{
  private void Search(int[][] grid1, int[][] grid2, int r, int c, ref bool isSubIslands)
  {
    if (r < 0 || c < 0 || r >= grid1.Length || c >= grid1[0].Length || grid2[r][c] == 0)
    {
      return;
    }
    if (grid1[r][c] != 1)
    {
      isSubIslands = false;
    }
    grid2[r][c] = 0;
    Search(grid1, grid2, r, c - 1, ref isSubIslands);
    Search(grid1, grid2, r, c + 1, ref isSubIslands);
    Search(grid1, grid2, r - 1, c, ref isSubIslands);
    Search(grid1, grid2, r + 1, c, ref isSubIslands);
  }

  public int CountSubIslands(int[][] grid1, int[][] grid2)
  {
    int count = 0;
    for (int r = 0; r < grid1.Length; r++)
    {
      for (int c = 0; c < grid1[0].Length; c++)
      {
        if (grid2[r][c] == 1)
        {
          bool isSubIslands = true;
          Search(grid1, grid2, r, c, ref isSubIslands);
          if (isSubIslands) count++;
        }
      }
    }
    return count;
  }
}
