/*
Determine Whether Matrix Can Be Obtained By Rotation
https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/

Given two n x n binary matrices mat and target, return true if it is possible to make mat equal to target by rotating mat in 90-degree increments, or false otherwise.

Example 1:
0 1      1 0
1 0  ->  0 1

Input: mat = [[0,1],[1,0]], target = [[1,0],[0,1]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise to make mat equal target.

Example 2:
Input: mat = [[0,1],[1,1]], target = [[1,0],[0,1]]
Output: false
Explanation: It is impossible to make mat equal to target by rotating mat.

Example 3:
0 0 0       1 0 0      1 1 1
0 1 0  -->  1 1 0  ->  0 1 0
1 1 1       1 0 0      0 0 0
Input: mat = [[0,0,0],[0,1,0],[1,1,1]], target = [[1,1,1],[0,1,0],[0,0,0]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise two times to make mat equal target.

Constraints:
n == mat.length == target.length
n == mat[i].length == target[i].length
1 <= n <= 10
mat[i][j] and target[i][j] are either 0 or 1.
*/

namespace LeetCode.DetermineWhetherMatrixCanBeObtainedByRotation;

public class Solution
{
  public bool FindRotation(int[][] mat, int[][] target)
  {
    int n = mat.Length;
    bool r1 = true, r2 = true, r3 = true, r4 = true;
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        // no rotate
        if (r1 && mat[i][j] != target[i][j]) r1 = false;

        // rotate 90
        if (r2 && mat[i][j] != target[j][n - 1 - i]) r2 = false;

        // rotate 180
        if (r3 && mat[i][j] != target[n - 1 - i][n - 1 - j]) r3 = false;

        // rotate 270
        if (r4 && mat[i][j] != target[n - 1 - j][i]) r4 = false;
      }
    }

    return r1 || r2 || r3 || r4;
  }
}
