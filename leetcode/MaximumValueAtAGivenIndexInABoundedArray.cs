/*
Maximum Value at a Given Index in a Bounded Array
https://leetcode.com/problems/maximum-value-at-a-given-index-in-a-bounded-array/

You are given three positive integers: n, index, and maxSum. 
You want to construct an array nums (0-indexed) that satisfies the following conditions:
- nums.length == n
- nums[i] is a positive integer where 0 <= i < n.
- abs(nums[i] - nums[i+1]) <= 1 where 0 <= i < n-1.
- The sum of all the elements of nums does not exceed maxSum.
- nums[index] is maximized.
Return nums[index] of the constructed array.
Note that abs(x) equals x if x >= 0, and -x otherwise.

Example 1:
Input: n = 4, index = 2,  maxSum = 6
Output: 2
Explanation: nums = [1,2,2,1] is one array that satisfies all the conditions.
There are no arrays that satisfy all the conditions and have nums[2] == 3, so 2 is the maximum nums[2].

Example 2:
Input: n = 6, index = 1,  maxSum = 10
Output: 3

Constraints:
1 <= n <= maxSum <= 10^9
0 <= index < n
*/

namespace LeetCode.MaximumValueAtAGivenIndexInABoundedArray;

public class Solution
{
  private bool Check(long mid, int n, int index, int max)
  {
    long sum = ((mid * (mid + 1)) / 2) + ((mid * (mid - 1)) / 2);
    if ((n - (mid + index)) >= 1) sum += (n - (mid + index));
    if (!(index - mid < 0)) sum += ((index - mid + 1));
    long left = mid - index - 1;
    long right = mid - (n - index - 1) - 1;
    if (left > 0) sum -= ((left * (left + 1)) / 2);
    if (right > 0) sum -= ((right * (right + 1)) / 2);
    return (sum) <= max;
  }

  public int MaxValue(int n, int index, int maxSum)
  {
    if (n == 1) return maxSum;
    if (maxSum == n) return 1;

    long lo = 1, hi = maxSum;
    int ans = 0;
    while (lo <= hi)
    {
      long mid = (lo + hi) / 2;
      if (Check(mid, n, index, maxSum))
      {
        ans = (int)mid;
        lo = mid + 1;
      }
      else hi = mid - 1;
    }
    return ans;
  }
}
