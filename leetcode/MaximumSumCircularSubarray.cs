/*
Maximum Sum Circular Subarray
https://leetcode.com/problems/maximum-sum-circular-subarray/

Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.
A circular array means the end of the array connects to the beginning of the array. 
Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].
A subarray may only include each element of the fixed buffer nums at most once. 
Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.

Example 1:
Input: nums = [1,-2,3,-2]
Output: 3
Explanation: Subarray [3] has maximum sum 3.

Example 2:
Input: nums = [5,-3,5]
Output: 10
Explanation: Subarray [5,5] has maximum sum 5 + 5 = 10.

Example 3:
Input: nums = [-3,-2,-3]
Output: -2
Explanation: Subarray [-2] has maximum sum -2.

Constraints:
n == nums.length
1 <= n <= 3 * 10^4
-3 * 10^4 <= nums[i] <= 3 * 10^4
*/

namespace LeetCode.MaximumSumCircularSubarray;

/*
intuitive thinking: `maxSum = sum of all elements - minSum`
case 1: [6, 7, -1, 3]
all sum = 15; minSum = -1; maxSum = 15 - (-1) = 16

case 2: [1, -3, 4, 5, -3, 4, -3]
all sum = 5; minSum = -3; maxSum = ~~8~~
however this maxSum should be 4 + 5 = 9

case 3: [-1, -2, -3, -4, -5]
all sum = -15; minSum = -15; maxSum = ~~0~~
maxSum should be -1

To conclude: 
if all element `sum` equals `minSum`, then `maxSum` is the answer
otherwise, the answer is: Math.Max(maxSum, sum - minSum)
*/
public class Solution
{
  public int MaxSubarraySumCircular(int[] nums)
  {
    int curMax = nums[0], maxSum = nums[0];
    int curMin = nums[0], minSum = nums[0];
    int sum = nums[0];

    for (int i = 1; i < nums.Length; i++)
    {
      // get max sum of subarray
      curMax = Math.Max(nums[i], curMax + nums[i]);
      maxSum = Math.Max(curMax, maxSum);

      // get min sum of subarray
      curMin = Math.Min(nums[i], curMin + nums[i]);
      minSum = Math.Min(curMin, minSum);

      // get all element sum
      sum += nums[i];
    }

    return sum == minSum ? maxSum : Math.Max(maxSum, sum - minSum);
  }
}
