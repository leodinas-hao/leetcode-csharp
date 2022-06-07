/*
Subarray Sums Divisible by K
https://leetcode.com/problems/subarray-sums-divisible-by-k/

Given an integer array nums and an integer k, return the number of non-empty subarrays that have a sum divisible by k.
A subarray is a contiguous part of an array.

Example 1:
Input: nums = [4,5,0,-2,-3,1], k = 5
Output: 7
Explanation: There are 7 subarrays with a sum divisible by k = 5:
[4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]

Example 2:
Input: nums = [5], k = 9
Output: 0

Constraints:
1 <= nums.length <= 3 * 10^4
-10^4 <= nums[i] <= 10^4
2 <= k <= 10^4
*/

namespace LeetCode.SubarraySumsDivisibleByK;

public class Solution
{
  public int SubarraysDivByK(int[] nums, int k)
  {
    int count = 0, sum = 0, remainder = 0;
    // dict to capture the reminders and associated number of occurrences
    // the idea behind this is when a % k = x && (a+b) % k = x then b is divisible by k
    var dict = new Dictionary<int, int>();
    dict.Add(0, 1);

    foreach (var num in nums)
    {
      sum += num;
      remainder = sum % k;
      // negative remainder need to be adjusted to positive by adding k
      if (remainder < 0)
      {
        remainder += k;
      }
      if (dict.ContainsKey(remainder))
      {
        count += dict[remainder];
        dict[remainder] += 1;
      }
      else
      {
        dict[remainder] = 1;
      }
    }

    return count;
  }
}

public class Solution2
{
  public int SubarraysDivByK(int[] nums, int k)
  {
    // brute force iterate the array to find all remainder 0's
    int count = 0;
    for (int i = 0; i < nums.Length; i++)
    {
      int sum = 0;
      for (int j = i; j < nums.Length; j++)
      {
        sum += nums[j];
        if (sum % k == 0)
        {
          count++;
        }
      }
    }

    return count;
  }
}