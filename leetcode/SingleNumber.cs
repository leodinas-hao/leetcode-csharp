/*
Single Number
https://leetcode.com/problems/single-number/

Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
You must implement a solution with a linear runtime complexity and use only constant extra space.

Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1

Constraints:
1 <= nums.length <= 3 * 10^4
-3 * 10^4 <= nums[i] <= 3 * 10^4
Each element in the array appears twice except for one element which appears only once.
*/

namespace LeetCode.SingleNumber;

public class Solution
{
  public int SingleNumber(int[] nums)
  {
    Array.Sort(nums);
    for (int i = 0; i < nums.Length - 1; i += 2)
    {
      if (nums[i] == nums[i + 1]) continue;
      else return nums[i];
    }
    return nums[nums.Length - 1]; // return the last item
  }
}

/*
put result of XOR of current and next element to next element
XOR of two same numbers is 0, XOR of any number with 0 is number itself
*/
public class Solution2
{
  public int SingleNumber(int[] nums)
  {
    for (int i = 0; i < nums.Length - 1; i++)
    {
      nums[i + 1] = nums[i] ^ nums[i + 1];
    }
    return nums[nums.Length - 1];
  }
}
