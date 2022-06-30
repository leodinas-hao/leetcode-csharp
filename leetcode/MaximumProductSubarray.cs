/*
Maximum Product Subarray
https://leetcode.com/problems/maximum-product-subarray/

Given an integer array nums, find a contiguous non-empty subarray within the array 
that has the largest product, and return the product.
The test cases are generated so that the answer will fit in a 32-bit integer.
A subarray is a contiguous subsequence of the array.

Example 1:
Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.

Example 2:
Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

Constraints:
1 <= nums.length <= 2 * 10^4
-10 <= nums[i] <= 10
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
*/

namespace LeetCode.MaximumProductSubarray;

public class Solution
{
  public int MaxProduct(int[] nums)
  {
    int ans = nums[0], max = nums[0], min = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
      if (nums[i] < 0)
      {
        var temp = max;
        max = min;
        min = temp;
      }
      max = Math.Max(nums[i], max * nums[i]);
      min = Math.Min(nums[i], min * nums[i]);
      ans = Math.Max(ans, max);
    }
    return ans;
  }
}

/*
brute force O(n^2)
*/
public class Solution2
{
  public int MaxProduct(int[] nums)
  {
    int ans = nums[0];

    for (int i = 0; i < nums.Length; i++)
    {
      int prod = 1;

      for (int j = i; j < nums.Length; j++)
      {
        prod *= nums[j];
        ans = Math.Max(ans, prod);
      }
    }
    return ans;
  }
}

/*
DP O(n)
if there are even number of negative digits, then the max product is the product of all
if there are odd number of negative digits, then the max product is either the product of left elements of the negative or the right elements
so check product twice, left to right & right to left
*/
public class Solution3
{
  public int MaxProduct(int[] nums)
  {
    int ans = nums[0], prod = 1;

    // left to right
    for (int i = 0; i < nums.Length; i++)
    {
      prod *= nums[i];
      ans = Math.Max(ans, prod);

      // restart when 0
      if (nums[i] == 0) prod = 1;
    }

    // right to left
    prod = 1;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
      prod *= nums[i];
      ans = Math.Max(ans, prod);

      if (nums[i] == 0) prod = 1;
    }
    return ans;
  }
}
