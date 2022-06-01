/*
As Far from Land as Possible
https://leetcode.com/problems/as-far-from-land-as-possible/

Given an n x n grid containing only values 0 and 1, where 0 represents water and 1 represents land, 
find a water cell such that its distance to the nearest land cell is maximized, and return the distance. 
If no land or water exists in the grid, return -1.

The distance used in this problem is the Manhattan distance: the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.

Example 1:
| 1 | 0 | 1 |
| 0 | 0 | 0 |
| 1 | 0 | 1 |

Input: grid = [[1,0,1],[0,0,0],[1,0,1]]
Output: 2
Explanation: The cell (1, 1) is as far as possible from all the land with distance 2.

Example 2:
| 1 | 0 | 0 |
| 0 | 0 | 0 |
| 0 | 0 | 0 |
Input: grid = [[1,0,0],[0,0,0],[0,0,0]]
Output: 4
Explanation: The cell (2, 2) is as far as possible from all the land with distance 4.

Constraints:
n == grid.length
n == grid[i].length
1 <= n <= 100
grid[i][j] is 0 or 1
*/

namespace LeetCode.AsFarFromLandAsPossible;

public class Solution
{
  public int MaxDistance(int[][] grid)
  {
    int n = grid.Length;
    // find all waters/lands and keep the coordinates in the array
    List<int[]> lands = new List<int[]>();
    List<int[]> waters = new List<int[]>();
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        if (grid[i][j] == 1)
        {
          lands.Add(new int[] { i, j });
        }
        else
        {
          waters.Add(new int[] { i, j });
        }
      }
    }

    if (lands.Count == 0 || waters.Count == 0)
    {
      // all lands/water, return -1 as per requirement
      return -1;
    }

    // max distance of the nearest land
    int max = 0;
    foreach (var water in waters)
    {
      int nearest = Int32.MaxValue;
      foreach (var land in lands)
      {
        var dis = GetDistance(land, water);
        if (dis == 1)
        {
          nearest = 1;
          break;  // no need to proceed as it can't be nearer than 1
        }
        nearest = Math.Min(dis, nearest);
      }
      max = Math.Max(max, nearest);
    }

    return max;
  }

  private int GetDistance(int[] a, int[] b)
  {
    return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
  }
}