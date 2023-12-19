/*
Image Smoother
https://leetcode.com/problems/image-smoother/

An image smoother is a filter of the size 3 x 3 that can be applied to each cell of an image 
by rounding down the average of the cell and the eight surrounding cells 
i.e., the average of the cell i(1, 1) [7] == (1+2+3+6+7+8+11+12+13)/9
If one or more of the surrounding cells of a cell is not present, we do not consider it in the average 
i.e., the average of the cell i(4, 4) [25] == (19+20+24+25)/4

| 1 | 2 | 3 | 4 | 5 |
| 6 | 7 | 8 | 9 | 10|
| 11| 12| 13| 14| 15|
| 16| 17| 18| 19| 20|
| 21| 22| 23| 24| 25|

Given an m x n integer matrix img representing the grayscale of an image, 
return the image after applying the smoother on each cell of it.

Example 1:

| 1 | 1 | 1 |    | 0 | 0 | 0 |
| 1 | 0 | 1 | -> | 0 | 0 | 0 |
| 1 | 1 | 1 |    | 0 | 0 | 0 |

Input: img = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[0,0,0],[0,0,0],[0,0,0]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the points (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0

Example 2:

|100|200|100|     |137|141|137|
|200| 50|200| --> |141|138|141|
|100|200|100|     |137|141|137|

Input: img = [[100,200,100],[200,50,200],[100,200,100]]
Output: [[137,141,137],[141,138,141],[137,141,137]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137.5) = 137
For the points (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) = floor(141.666667) = 141
For the point (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.888889) = 138

Constraints:
m == img.length
n == img[i].length
1 <= m, n <= 200
0 <= img[i][j] <= 255
*/

namespace LeetCode.ImageSmoother;

public class Solution
{
  private int[][] matrix;

  private int Average(int row, int col)
  {
    int sum = 0, count = 0;
    for (int i = row - 1; i <= row + 1; i++)
    {
      for (int j = col - 1; j <= col + 1; j++)
      {
        if (i >= 0 && i < matrix.Length && j >= 0 && j < matrix[i].Length)
        {
          sum += matrix[i][j];
          count++;
        }
      }
    }
    return sum / count;
  }

  public int[][] ImageSmoother(int[][] img)
  {
    matrix = img;
    int[][] result = new int[img.Length][];

    for (int i = 0; i < img.Length; i++)
    {
      result[i] = new int[img[i].Length];
      for (int j = 0; j < img[i].Length; j++)
      {
        result[i][j] = Average(i, j);
      }
    }

    return result;
  }
}
