/*
Delete and earn
https://leetcode.com/problems/delete-and-earn/

You are given an integer array nums. You want to maximize the number of points you get by performing the following operation any number of times:

Pick any nums[i] and delete it to earn nums[i] points. Afterwards, you must delete every element equal to nums[i] - 1 and every element equal to nums[i] + 1.
Return the maximum number of points you can earn by applying the above operation some number of times. 

Example 1:
Input: nums = [3,4,2]
Output: 6
Explanation: You can perform the following operations:
- Delete 4 to earn 4 points. Consequently, 3 is also deleted. nums = [2].
- Delete 2 to earn 2 points. nums = [].
You earn a total of 6 points.

Example 2:
Input: nums = [2,2,3,3,3,4]
Output: 9
Explanation: You can perform the following operations:
- Delete a 3 to earn 3 points. All 2's and 4's are also deleted. nums = [3,3].
- Delete a 3 again to earn 3 points. nums = [3].
- Delete a 3 once more to earn 3 points. nums = [].
You earn a total of 9 points.

Constraints:
1 <= nums.length <= 2 * 10^4
1 <= nums[i] <= 10^4
*/

namespace LeetCode.DeleteAndEarn;

public class Solution
{
  // a map of (value, points = value * number of occurrence)
  private Dictionary<int, int> points = new Dictionary<int, int>();
  // cache previous findings to avoid recalculation
  private Dictionary<int, int> cache = new Dictionary<int, int>();

  private int EarnMax(int n)
  {
    // base case
    if (n <= 0) return 0;
    if (n == 1) return points.GetValueOrDefault(1, 0);

    // check cache
    if (cache.ContainsKey(n)) return cache[n];

    int gain = points.GetValueOrDefault(n, 0);
    // apply recurrence if taking the gain (next checking: n-2) or not (next checking n-1)
    cache.Add(n, Math.Max(EarnMax(n - 1), EarnMax(n - 2) + gain));
    return cache[n];
  }

  public int DeleteAndEarn(int[] nums)
  {
    // keep track of max value
    int max = -1;
    // iterate each value in nums to populate points
    foreach (var n in nums)
    {
      if (points.ContainsKey(n)) points[n] += n;
      else points.Add(n, n);
      max = Math.Max(max, n);
    }

    // Top-down DP by starting from the max value towards the base case
    // by starting from max, then no need to worry about any points from max+1
    // just checking if taking point of max, then can't take points of max-1; otherwise, can keep taking points of max-2
    return EarnMax(max);
  }
}

public class Solution2
{
  /*
   * Bottom-up DP
   */
  public int DeleteAndEarn(int[] nums)
  {
    // a map of (value, points = value * number of occurrence)
    var points = new Dictionary<int, int>();
    // keep track of max value
    int max = -1;
    // iterate each value in nums to populate points
    foreach (var n in nums)
    {
      if (points.ContainsKey(n)) points[n] += n;
      else points.Add(n, n);
      max = Math.Max(max, n);
    }

    // array to track the points of all possible values between 0 to max
    var maxPoints = new int[max + 1];
    // given constraints nums[i] >=1, no points of 0 value
    // base case with value 1
    maxPoints[1] = points.GetValueOrDefault(1, 0);

    // iterate from value 2 to max value to find the max points
    for (int i = 2; i < maxPoints.Length; i++)
    {
      int gain = points.GetValueOrDefault(i, 0);
      maxPoints[i] = Math.Max(maxPoints[i - 1], maxPoints[i - 2] + gain);
    }
    return maxPoints[max];
  }
}