/*
Search a 2D Matrix
https://leetcode.com/problems/search-a-2d-matrix/

Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. 
This matrix has the following properties:
Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.

Example 1:
 1,  3,  5,  7
10, 11, 16, 20
23, 30, 34, 60

Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true

Example 2:
 1,  3,  5,  7
10, 11, 16, 20
23, 30, 34, 60

Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-10^4 <= matrix[i][j], target <= 10^4
*/

namespace LeetCode.Search2DMatrix;

public class Solution
{
  public bool SearchMatrix(int[][] matrix, int target)
  {
    int rows = matrix.Length, cols = matrix[0].Length;
    int lo = 0, hi = rows * cols - 1;
    while (lo <= hi)
    {
      int mid = lo + (hi - lo) / 2;
      // convert position index (0 based) to 2D array indices
      int r = mid / cols;
      int c = mid % cols;
      if (matrix[r][c] == target) return true;
      else if (matrix[r][c] < target) lo = mid + 1;
      else hi = mid - 1;
    }
    return false;
  }
}
