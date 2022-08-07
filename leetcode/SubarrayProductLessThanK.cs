/*
Subarray Product Less Than K
https://leetcode.com/problems/subarray-product-less-than-k/

Given an array of integers nums and an integer k, return the number of contiguous subarrays where the product of all the elements in the subarray is strictly less than k.

Example 1:
Input: nums = [10,5,2,6], k = 100
Output: 8
Explanation: The 8 subarrays that have product less than 100 are:
[10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]
Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.

Example 2:
Input: nums = [1,2,3], k = 0
Output: 0

Constraints:
1 <= nums.length <= 3 * 10^4
1 <= nums[i] <= 1000
0 <= k <= 10^6
*/

namespace LeetCode.SubarrayProductLessThanK;

/*
sliding window/two pointers
*/
public class Solution
{
  public int NumSubarrayProductLessThanK(int[] nums, int k)
  {
    if (k <= 1) return 0;
    int result = 0, left = 0, right = 0, product = 1;
    while (right < nums.Length)
    {
      product *= nums[right];
      while (product >= k)
      {
        product /= nums[left];
        left++;
      }
      result += right - left + 1;
      right++;
    }
    return result;
  }
}


/*
binary search
*/
public class Solution2
{
  public int NumSubarrayProductLessThanK(int[] nums, int k)
  {
    if (k <= 1) return 0;
    double logk = Math.Log(k);
    double[] prefix = new double[nums.Length + 1];
    for (int i = 0; i < nums.Length; i++)
    {
      prefix[i + 1] = prefix[i] + Math.Log(nums[i]);
    }

    int ans = 0;
    for (int i = 0; i < prefix.Length; i++)
    {
      int lo = i + 1, hi = prefix.Length;
      while (lo < hi)
      {
        int mi = lo + (hi - lo) / 2;
        if (prefix[mi] < prefix[i] + logk - 1e-9) lo = mi + 1;
        else hi = mi;
      }
      ans += lo - i - 1;
    }
    return ans;
  }
}