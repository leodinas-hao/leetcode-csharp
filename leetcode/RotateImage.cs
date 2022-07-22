/*
rotate image
https://leetcode.com/problems/rotate-image/

You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

Example 1:
1 2 3      7 4 1
4 5 6  ->  8 5 2
7 8 9      9 6 3

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]

Example 2:
5  1  9  11      15 13 2  5 
2  4  8  10      14 3  4  1
13 3  6  7   ->  12 6  8  9
15 14 12 16      16 7  10 11
Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

Constraints:
n == matrix.length == matrix[i].length
1 <= n <= 20
-1000 <= matrix[i][j] <= 1000
*/

namespace LeetCode.RotateImage;

public class Solution
{
  public void Rotate(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = 0; i < (n + 1) / 2; i++)
    {
      for (int j = 0; j < n / 2; j++)
      {
        int temp = matrix[n - 1 - j][i];
        matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
        matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
        matrix[j][n - 1 - i] = matrix[i][j];
        matrix[i][j] = temp;
      }
    }
  }
}

public class Solution2
{
  private void Transpose(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = 0; i < n; i++)
    {
      for (int j = i + 1; j < n; j++)
      {
        int tmp = matrix[j][i];
        matrix[j][i] = matrix[i][j];
        matrix[i][j] = tmp;
      }
    }
  }

  private void Reflect(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n / 2; j++)
      {
        int tmp = matrix[i][j];
        matrix[i][j] = matrix[i][n - j - 1];
        matrix[i][n - j - 1] = tmp;
      }
    }
  }

  public void Rotate(int[][] matrix)
  {
    Transpose(matrix);
    Reflect(matrix);
  }
}

public class Solution3
{
  public void Rotate(int[][] matrix)
  {
    int n = matrix.Length;

    for (int i = 0; i < n; i++)
    {
      Array.Reverse(matrix[i]);
    }

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n - i; j++)
      {
        int tmp = matrix[i][j];
        matrix[i][j] = matrix[n - j - 1][n - i - 1];
        matrix[n - j - 1][n - i - 1] = tmp;
      }
    }
  }
}
