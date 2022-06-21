/*
01 Matrix
https://leetcode.com/problems/01-matrix/

Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.

The distance between two adjacent cells is 1.

Example 1:
[0,0,0],
[0,1,0],
[0,0,0],
Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
Output: [[0,0,0],[0,1,0],[0,0,0]]

Example 2:
[0,0,0],
[0,1,0],
[1,1,1],
Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
Output: [[0,0,0],[0,1,0],[1,2,1]]

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 10^4
1 <= m * n <= 10^4
mat[i][j] is either 0 or 1.
There is at least one 0 in mat.
*/

namespace LeetCode.Matrix01;

/*
dynamic programming (DP)
update distances of 1's while iterations
1st check left & top cells; then check bottom & right cells
*/
public class Solution2
{
  public int[][] UpdateMatrix(int[][] mat)
  {
    int rows = mat.Length;
    int cols = mat[0].Length;
    int[][] updated = new int[rows][];
    for (int i = 0; i < rows; i++)
    {
      updated[i] = new int[cols];
      // fill the matrix with MaxValue - 10^4 to avoid overflow
      Array.Fill(updated[i], Int32.MaxValue - 100000);
    }

    // check left & top
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        if (mat[i][j] == 0)
        {
          updated[i][j] = 0;
        }
        else
        {
          if (i > 0) updated[i][j] = Math.Min(updated[i][j], updated[i - 1][j] + 1);
          if (j > 0) updated[i][j] = Math.Min(updated[i][j], updated[i][j - 1] + 1);
        }
      }
    }

    // check bottom & right
    for (int i = rows - 1; i >= 0; i--)
    {
      for (int j = cols - 1; j >= 0; j--)
      {
        if (i < rows - 1) updated[i][j] = Math.Min(updated[i][j], updated[i + 1][j] + 1);
        if (j < cols - 1) updated[i][j] = Math.Min(updated[i][j], updated[i][j + 1] + 1);
      }
    }

    return updated;
  }
}


/*
BFS from 0's and update 1's with distance
*/
public class Solution
{
  public int[][] UpdateMatrix(int[][] mat)
  {
    int rows = mat.Length;
    int cols = mat[0].Length;
    int[][] updated = new int[rows][];
    for (int i = 0; i < rows; i++)
    {
      updated[i] = new int[cols];
      // fill the matrix with MaxValue
      Array.Fill(updated[i], Int32.MaxValue);
    }

    var queue = new Queue<ValueTuple<int, int>>();
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        if (mat[i][j] == 0)
        {
          updated[i][j] = 0;
          // queue all 0's to search nearby MaxValue
          queue.Enqueue((i, j));
        }
      }
    }

    ValueTuple<int, int>[] dirs = {
      (-1, 0), (1, 0), (0, -1), (0, 1),
    };

    int r, c;
    while (queue.Any())
    {
      (r, c) = queue.Dequeue();
      foreach (var d in dirs)
      {
        int rNext = r + d.Item1;
        int cNext = c + d.Item2;
        if (rNext >= 0 && cNext >= 0 && rNext < rows && cNext < cols)
        {
          // cell with MaxValue is the one needs to be updated
          if (updated[rNext][cNext] > updated[r][c] + 1)
          {
            updated[rNext][cNext] = updated[r][c] + 1;
            queue.Enqueue((rNext, cNext));
          }
        }
      }
    }

    return updated;
  }
}
