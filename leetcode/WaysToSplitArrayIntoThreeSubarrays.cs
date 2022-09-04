/*
Ways to Split Array Into Three Subarrays
https://leetcode.com/problems/ways-to-split-array-into-three-subarrays/

A split of an integer array is good if:
The array is split into three non-empty contiguous subarrays - named left, mid, right respectively from left to right.
The sum of the elements in left is less than or equal to the sum of the elements in mid, 
and the sum of the elements in mid is less than or equal to the sum of the elements in right.
Given nums, an array of non-negative integers, return the number of good ways to split nums. 
As the number may be too large, return it modulo 10^9 + 7.

Example 1:
Input: nums = [1,1,1]
Output: 1
Explanation: The only good way to split nums is [1] [1] [1].

Example 2:
Input: nums = [1,2,2,2,5,0]
Output: 3
Explanation: There are three good ways of splitting nums:
[1] [2] [2,2,5,0]
[1] [2,2] [2,5,0]
[1,2] [2,2] [5,0]

Example 3:
Input: nums = [3,2,1]
Output: 0
Explanation: There is no good way to split nums.

Constraints:
3 <= nums.length <= 10^5
0 <= nums[i] <= 10^4
*/

namespace LeetCode.WaysToSplitArrayIntoThreeSubarrays;

public class Solution
{
  public int WaysToSplit(int[] nums)
  {
    int mod = (int)Math.Pow(10, 9) + 7;
    int len = nums.Length;
    int sum = nums.Sum();
    long result = 0;
    int[] prefixSum = new int[len];
    prefixSum[0] = nums[0];
    for (int i = 1; i < len - 1; i++)
    {
      prefixSum[i] = prefixSum[i - 1] + nums[i];
      if (2 * prefixSum[i] - sum <= prefixSum[i] / 2)
      {
        int lo = 0, hi = i - 1;
        while (lo <= hi)
        {
          int mid = (lo + hi) / 2;
          if (prefixSum[mid] >= 2 * prefixSum[i] - sum) hi = mid - 1;
          else lo = mid + 1;
        }
        int left = lo;
        lo = 0; hi = i - 1;
        while (lo <= hi)
        {
          int mid = (hi + lo) / 2;
          if (prefixSum[mid] > prefixSum[i] / 2) hi = mid - 1;
          else lo = mid + 1;
        }
        int right = hi;
        result = (result + (right - left + 1)) % mod;
      }
    }
    return (int)result;
  }
}