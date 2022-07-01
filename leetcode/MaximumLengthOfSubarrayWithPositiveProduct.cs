/*
Maximum Length of Subarray With Positive Product
https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/

Given an array of integers nums, find the maximum length of a subarray where the product of all its elements is positive.
A subarray of an array is a consecutive sequence of zero or more values taken out of that array.
Return the maximum length of a subarray with positive product.

Example 1:
Input: nums = [1,-2,-3,4]
Output: 4
Explanation: The array nums already has a positive product of 24.

Example 2:
Input: nums = [0,1,-2,-3,-4]
Output: 3
Explanation: The longest subarray with positive product is [1,-2,-3] which has a product of 6.
Notice that we cannot include 0 in the subarray since that'll make the product 0 which is not positive.

Example 3:
Input: nums = [-1,-2,-3,0,1]
Output: 2
Explanation: The longest subarray with positive product is [-1,-2] or [-2,-3].

Constraints:
1 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9
*/

namespace LeetCode.MaximumLengthOfSubarrayWithPositiveProduct;

/*
similar to `LeetCode.MaximumProductSubarray.Solution3`
run 2 loops, one from left and one from right
*/
public class Solution
{
  public int GetMaxLen(int[] nums)
  {
    int ans = 0, sign = 1, len = 0;
    for (int i = 0; i < nums.Length; i++)
    {
      if (nums[i] == 0)
      {
        sign = 1;
        len = 0;
      }
      else
      {
        if (nums[i] < 0) sign *= -1;
        len++;
        if (sign == 1) ans = Math.Max(ans, len);
      }
    }

    sign = 1; len = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
      if (nums[i] == 0)
      {
        sign = 1;
        len = 0;
      }
      else
      {
        if (nums[i] < 0) sign *= -1;
        len++;
        if (sign == 1) ans = Math.Max(ans, len);
      }
    }

    return ans;
  }
}