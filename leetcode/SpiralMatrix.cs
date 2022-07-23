/*
Spiral Matrix
https://leetcode.com/problems/spiral-matrix/

Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
[1,2,3]
[4,5,6]
[7,8,9]
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
[1, 2, 3, 4 ]
[5, 6, 7, 8 ]
[9, 10,11,12]
Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
-100 <= matrix[i][j] <= 100
*/

namespace LeetCode.SpiralMatrix;

public class Solution
{
  public IList<int> SpiralOrder(int[][] matrix)
  {
    int rows = matrix.Length, cols = matrix[0].Length;
    var directions = new ValueTuple<int, int>[]{
      (0,1), (1,0), (0,-1), (-1,0)
    };
    int dir = 0; // 0: right, 1: down, 2: left, 3: up
    int row = 0, col = 0;
    var ls = new List<int>();
    for (int i = 0; i < rows * cols; i++)
    {
      ls.Add(matrix[row][col]);
      // mark the cell as visited
      matrix[row][col] = Int32.MinValue;
      var nextRow = row + directions[dir].Item1;
      var nextCol = col + directions[dir].Item2;
      // check if next movement is possible
      if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || matrix[nextRow][nextCol] == Int32.MinValue)
      {
        // change direction
        dir = (dir + 1) % 4;
        nextRow = row + directions[dir].Item1;
        nextCol = col + directions[dir].Item2;
      }
      row = nextRow;
      col = nextCol;
    }
    return ls;
  }
}
