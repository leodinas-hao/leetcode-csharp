/*
Best sightseeing pair
https://leetcode.com/problems/best-sightseeing-pair/

You are given an integer array values where values[i] represents the value of the ith sightseeing spot. Two sightseeing spots i and j have a distance j - i between them.
The score of a pair (i < j) of sightseeing spots is values[i] + values[j] + i - j: the sum of the values of the sightseeing spots, minus the distance between them.
Return the maximum score of a pair of sightseeing spots.

Example 1:
Input: values = [8,1,5,2,6]
Output: 11
Explanation: i = 0, j = 2, values[i] + values[j] + i - j = 8 + 5 + 0 - 2 = 11

Example 2:
Input: values = [1,2]
Output: 2

Constraints:

2 <= values.length <= 5 * 10^4
1 <= values[i] <= 1000
*/

namespace LeetCode.BestSightseeingPair;


/*
DP
*/
public class Solution
{
  public int MaxScoreSightseeingPair(int[] values)
  {
    int val = values[0] + 0;
    int max = val + values[1] - 1;
    for (int i = 1; i < values.Length; i++)
    {
      max = Math.Max(max, val + values[i] - i);
      val = Math.Max(val, values[i] + i);
    }
    return max;
  }
}

/*
brute force
Time Limit Exceeded when input array is too large on LeetCode
*/
public class Solution2
{
  public int MaxScoreSightseeingPair(int[] values)
  {
    int max = 0;

    for (int i = 0; i < values.Length; i++)
    {
      for (int j = i + 1; j < values.Length; j++)
      {
        max = Math.Max(max, values[i] + values[j] + i - j);
      }
    }
    return max;
  }
}


