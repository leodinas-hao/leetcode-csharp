/*
Split Array Largest Sum

Given an array nums which consists of non-negative integers and an integer m, you can split the array into m non-empty continuous subarrays.

Write an algorithm to **minimize** the largest sum among these m subarrays.

Example 1:
Input: nums = [7,2,5,10,8], m = 2
Output: 18
Explanation:
There are four ways to split nums into two subarrays.
The best way is to split it into [7,2,5] and [10,8],
where the largest sum among the two subarrays is only 18.

Example 2:
Input: nums = [1,2,3,4,5], m = 2
Output: 9

Example 3:
Input: nums = [1,4,4], m = 3
Output: 4

Constraints:
1 <= nums.length <= 1000
0 <= nums[i] <= 10^6
1 <= m <= min(50, nums.length)
*/

namespace LeetCode.SplitArrayLargestSum;


public class Solution
{
  public int SplitArray(int[] nums, int m)
  {
    // find the boundary of the result
    // between max element & total sum
    int maxElement = -1;
    int totalSum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
      maxElement = Math.Max(nums[i], maxElement);
      totalSum += nums[i];
    }

    // quick way out if m == 1; then the total sum is the answer
    if (m == 1)
    {
      return totalSum;
    }

    // try to find a solution, which can meet the best guessing boundary
    int left = maxElement;
    int right = totalSum;
    int minimumLargestSum = 0;
    while (left <= right)
    {
      // get a mid value, which can be the best guessing minimized max sum
      int maxSumAllow = left + (right - left) / 2;

      // find the minimum splits
      // if split is less than or equal to "m", move the the maxSumAllow to smaller
      // otherwise increase maxSumAllow
      if (MinimumSplits(nums, maxSumAllow) <= m)
      {
        // there might be a better solution/split
        // try to decrease the boundary
        right = maxSumAllow - 1;
        minimumLargestSum = maxSumAllow;
      }
      else
      {
        // need to increase the guessing to make the required split
        left = maxSumAllow + 1;
      }
    }

    return minimumLargestSum;
  }

  private int MinimumSplits(int[] nums, int maxSumAllow)
  {
    int sum = 0;
    int splits = 0;

    foreach (int n in nums)
    {
      if (sum + n <= maxSumAllow)
      {
        // not exceeding the max sum, keep adding to this split
        sum += n;
      }
      else
      {
        // exceeded the max sum, more split required
        sum = n;  // reset the sum
        splits++;
      }
    }

    // return number of subarrays, which is splits + 1
    return splits + 1;
  }
}
