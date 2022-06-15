/*
Rotate Array
https://leetcode.com/problems/rotate-array/

Given an array, rotate the array to the right by k steps, where k is non-negative.

Example 1:
Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]

Example 2:
Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]

Constraints:
1 <= nums.length <= 10^5
-2^31 <= nums[i] <= 2^31 - 1
0 <= k <= 10^5

Follow up:
Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
Could you do it in-place with O(1) extra space?
*/

namespace LeetCode.RotateArray;

public class Solution
{
  public void Rotate(int[] nums, int k)
  {
    int n = nums.Length;
    k = k % n; // if k >= n, to avoid running a cycle
    if (n == 0 || n == 1 || k == 0) return;
    int[] copy = new int[n];
    Array.Copy(nums, copy, n);
    for (int i = 0; i < n; i++)
    {
      nums[(i + k) % n] = copy[i];
    }
  }
}

public class Solution2
{
  private void Reverse(int[] nums, int start, int end)
  {
    while (start <= end)
    {
      int temp = nums[start];
      nums[start] = nums[end];
      nums[end] = temp;
      start++;
      end--;
    }
  }

  public void Rotate(int[] nums, int k)
  {
    int n = nums.Length;
    k = k % n; // if k >= n, to avoid running a cycle
    if (n == 0 || n == 1 || k == 0) return;

    Reverse(nums, 0, n - 1);  // reverse the array from start to end
    Reverse(nums, 0, k - 1);  // reverse the array from start to k-1
    Reverse(nums, k, n - 1);  // reverse the array from k to end
  }
}
