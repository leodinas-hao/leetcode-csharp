/*
Minimum Moves to Equal Array Elements II
https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/

Given an integer array nums of size n, return the minimum number of moves required to make all array elements equal.
In one move, you can increment or decrement an element of the array by 1.
Test cases are designed so that the answer will fit in a 32-bit integer.

Example 1:
Input: nums = [1,2,3]
Output: 2
Explanation:
Only two moves are needed (remember each move increments or decrements one element):
[1,2,3]  =>  [2,2,3]  =>  [2,2,2]

Example 2:
Input: nums = [1,10,2,9]
Output: 16

Constraints:
n == nums.length
1 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9
*/

namespace LeetCode.MinimumMovesToEqualArrayElementsII;

public class Solution
{
  public int MinMoves2(int[] nums)
  {
    // calculate the average of all elements
    // int avg = nums.Sum() / nums.Length;
    // sum the gap of each elements (need to move to average)
    // return nums.Sum((n) => Math.Abs(n - avg));
    // above won't work. consider input: [1, 0, 0, 8, 6], the minimum move is 14
    // however moving to average will result in 16

    // find the median of the list (midpoint of data)
    Array.Sort(nums);
    int median = nums[nums.Length / 2];
    // sum the gap of each elements (need to move to median)
    return nums.Sum((n) => Math.Abs(n - median));
  }
}
