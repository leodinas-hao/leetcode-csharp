/*
Max Points on a Line
https://leetcode.com/problems/max-points-on-a-line/

Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, 
return the maximum number of points that lie on the same straight line.

Example 1:
Input: points = [[1,1],[2,2],[3,3]]
Output: 3

Example 2:
Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
Output: 4

Constraints:
1 <= points.length <= 300
points[i].length == 2
-10^4 <= xi, yi <= 10^4
All the points are unique.
*/

namespace LeetCode.MaxPointsOnALine;

public class Solution
{
  private int n; // number of points
  private int[][] points;
  // line slope (int, int) with the count of number of points
  // if point `a` (x1,y1) and `b` (x2,y2), then the slope of the line of `a` & `b` should be:
  // slope = (y2-y1)/(x2-x1)
  // to avoid fraction number (floating number) equation issue, put numerator & denominator instead
  private Dictionary<(int, int), int> lines;

  // when x2 == x1, then the line is horizontal
  // mark number of horizontal lines
  private int horizontal;


  private (int, int) GetSlope(int x1, int y1, int x2, int y2)
  {
    int deltaX = x1 - x2, deltaY = y1 - y2;

    // vertical line
    if (deltaX == 0) return (0, 0);
    // horizontal line
    if (deltaY == 0) return (Int32.MaxValue, Int32.MaxValue);
    if (deltaX < 0)
    {
      deltaX = -deltaX;
      deltaY = -deltaY;
    }
    // use greatest common divisor to reduce to the lowest term
    int gcd = (int)System.Numerics.BigInteger.GreatestCommonDivisor(deltaX, deltaY);
    return (deltaX / gcd, deltaY / gcd);
  }

  /*
  add line passing Point i & j
  calculate the max count & duplicates
  return the pair value of (count, duplicates)
  */
  private (int, int) AddLine(int i, int j, int count, int duplicates)
  {
    int x1 = points[i][0], y1 = points[i][1];
    int x2 = points[j][0], y2 = points[j][1];

    // check point i & j are the same
    if (x1 == x2 && y1 == y2) duplicates++;
    // horizontal line
    else if (y1 == y2)
    {
      horizontal++;
      count = Math.Max(horizontal, count);
    }
    else
    {
      // add slope of a line to `lines` dictionary
      var slope = GetSlope(x1, y1, x2, y2);
      if (lines.ContainsKey(slope)) lines[slope] += 1;
      else lines.Add(slope, 2);
      count = Math.Max(count, lines[slope]);
    }

    return (count, duplicates);
  }

  /*
  checks the max points on a line, which containing the Point `i`
  */
  private int Helper(int i)
  {
    lines = new Dictionary<(int, int), int>();
    horizontal = 1;
    int count = 1; // count 1 line on Point i 
    int duplicates = 0; // mark duplicated points

    // calculate lines passing through point i
    for (int j = i + 1; j < n; j++)
    {
      (count, duplicates) = AddLine(i, j, count, duplicates);
    }

    return count + duplicates;
  }

  public int MaxPoints(int[][] points)
  {
    this.points = points;
    n = points.Length;
    if (n < 3) return n; // 2 points or less

    int max = 1;

    // iterate points [0, n-1] to find the max points on a line
    for (int i = 0; i < n - 1; i++)
    {
      max = Math.Max(max, Helper(i));
    }

    return max;
  }
}
