/*
Pacific Atlantic Water Flow
https://leetcode.com/problems/pacific-atlantic-water-flow/

There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. 
The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights 
where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).

The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, 
and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.

Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can 
flow from cell (ri, ci) to both the Pacific and Atlantic oceans.


Example 1:
Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]

Example 2:
Input: heights = [[2,1],[1,2]]
Output: [[0,0],[0,1],[1,0],[1,1]]

Constraints:

m == heights.length
n == heights[r].length
1 <= m, n <= 200
0 <= heights[r][c] <= 10^5
*/

namespace LeetCode.PacificAtlanticWaterFlow;

public class Solution
{
  private void IsReachable(int[][] heights, int r, int c, ref bool pacific, ref bool atlantic, bool[,] visited)
  {
    if (r <= 0 || c <= 0) { pacific = true; }
    if (r >= heights.Length - 1 || c >= heights[0].Length - 1) { atlantic = true; }

    // no need to check further
    if (pacific && atlantic) return;
    // mark the pos visited
    visited[r, c] = true;

    // move up
    if (r > 0 && !visited[r - 1, c] && heights[r][c] >= heights[r - 1][c])
      IsReachable(heights, r - 1, c, ref pacific, ref atlantic, visited);
    // move down
    if (r < heights.Length - 1 && !visited[r + 1, c] && heights[r][c] >= heights[r + 1][c])
      IsReachable(heights, r + 1, c, ref pacific, ref atlantic, visited);
    // move left
    if (c > 0 && !visited[r, c - 1] && heights[r][c] >= heights[r][c - 1])
      IsReachable(heights, r, c - 1, ref pacific, ref atlantic, visited);
    // move right
    if (c < heights[0].Length - 1 && !visited[r, c + 1] && heights[r][c] >= heights[r][c + 1])
      IsReachable(heights, r, c + 1, ref pacific, ref atlantic, visited);
  }

  public IList<IList<int>> PacificAtlantic(int[][] heights)
  {
    var result = new List<IList<int>>();
    for (int r = 0; r < heights.Length; r++)
    {
      for (int c = 0; c < heights[0].Length; c++)
      {
        bool pacific = false, atlantic = false;
        IsReachable(heights, r, c, ref pacific, ref atlantic, new bool[heights.Length, heights[0].Length]);
        if (pacific && atlantic)
        {
          result.Add(new int[] { r, c });
        }
      }
    }
    return result;
  }
}
