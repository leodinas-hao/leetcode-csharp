/*
K Closest Points to Origin
https://leetcode.com/problems/k-closest-points-to-origin/

Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).
The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)^2 + (y1 - y2)^2).
You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).

Example 1:
Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Explanation:
The distance between (1, 3) and the origin is sqrt(10).
The distance between (-2, 2) and the origin is sqrt(8).
Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].

Example 2:
Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]
Explanation: The answer [[-2,4],[3,3]] would also be accepted.


Constraints:
1 <= k <= points.length <= 10^4
-10^4 < xi, yi < 10^4
*/

namespace LeetCode.KClosestPointsToOrigin;

public class Solution
{
  public int[][] KClosest(int[][] points, int k)
  {
    return points.OrderBy(point => point[0] * point[0] + point[1] * point[1]).Take(k).ToArray();
  }
}


/*
binary search to find the k closest points to the origin
*/
public class Solution2
{
  public int[][] KClosest(int[][] points, int k)
  {
    // calculate distance of each point
    // define initial binary search range
    // and create a reference list of point indices
    var distances = new double[points.Length];
    double low = 0, high = 0;
    IList<int> indices = new List<int>();
    for (int i = 0; i < points.Length; i++)
    {
      distances[i] = points[i][0] * points[i][0] + points[i][1] * points[i][1];
      indices.Add(i);
      high = Math.Max(high, distances[i]);
    }

    // binary search to find the k closest points to the origin
    var closest = new List<int>();
    while (k > 0)
    {
      var mid = low + (high - low) / 2;
      var result = SplitDistance(indices, distances, mid);
      var closer = result[0];
      var further = result[1];
      if (closer.Count > k)
      {
        // more than k points in closer
        // discard further points
        indices = closer;
        high = mid;
      }
      else
      {
        // less than k points in closer
        // search further points for remaining points
        k -= closer.Count;
        closest.AddRange(closer);
        indices = further;
        low = mid;
      }
    }

    k = closest.Count;
    var answer = new int[k][];
    for (int i = 0; i < k; i++)
    {
      answer[i] = points[closest[i]];
    }
    return answer;
  }

  private IList<IList<int>> SplitDistance(IList<int> indices, double[] distances, double mid)
  {
    // split the indices list into two lists
    var result = new List<IList<int>>();
    var closer = new List<int>();
    var further = new List<int>();
    for (int i = 0; i < indices.Count; i++)
    {
      if (distances[indices[i]] <= mid)
      {
        closer.Add(indices[i]);
      }
      else
      {
        further.Add(indices[i]);
      }
    }
    result.Add(closer);
    result.Add(further);
    return result;
  }
}