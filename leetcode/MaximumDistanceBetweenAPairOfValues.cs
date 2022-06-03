/*
Maximum Distance Between a Pair of Values
https://leetcode.com/problems/maximum-distance-between-a-pair-of-values/

You are given two non-increasing 0-indexed integer arrays nums1​​​​​​ and nums2​​​​​​.

A pair of indices (i, j), where 0 <= i < nums1.length and 0 <= j < nums2.length, 
is valid if both i <= j and nums1[i] <= nums2[j]. The distance of the pair is j - i​​​​.
Return the maximum distance of any valid pair (i, j). If there are no valid pairs, return 0.
An array arr is non-increasing if arr[i-1] >= arr[i] for every 1 <= i < arr.length.

Example 1:
Input: nums1 = [55,30,5,4,2], nums2 = [100,20,10,10,5]
Output: 2
Explanation: The valid pairs are (0,0), (2,2), (2,3), (2,4), (3,3), (3,4), and (4,4).
The maximum distance is 2 with pair (2,4).

Example 2:
Input: nums1 = [2,2,2], nums2 = [10,10,1]
Output: 1
Explanation: The valid pairs are (0,0), (0,1), and (1,1).
The maximum distance is 1 with pair (0,1).

Example 3:
Input: nums1 = [30,29,19,5], nums2 = [25,25,25,25,25]
Output: 2
Explanation: The valid pairs are (2,2), (2,3), (2,4), (3,3), and (3,4).
The maximum distance is 2 with pair (2,4).

Constraints:
1 <= nums1.length, nums2.length <= 10^5
1 <= nums1[i], nums2[j] <= 10^5
Both nums1 and nums2 are non-increasing.
*/

namespace LeetCode.MaximumDistanceBetweenAPairOfValues;

public class Solution
{
  public int MaxDistance(int[] nums1, int[] nums2)
  {
    int max = 0;
    for (int i = 0; i < nums1.Length; i++)
    {
      // binary search in nums2 to find the right position
      int left = i;
      int right = nums2.Length - 1;
      while (left <= right)
      {
        int mid = left + (right - left) / 2;
        // move to a higher number by moving right -1
        if (nums1[i] > nums2[mid]) right = mid - 1;
        // nums2[mid]>= nums[i]: stretch it to see if a smaller number in nums2 is also >= nums1[i]
        else left = mid + 1;
      }
      max = Math.Max(max, right - i);
    }

    return max;
  }
}

public class Solution2
{
  public int MaxDistance(int[] nums1, int[] nums2)
  {
    int max = 0, i = 0, j = 0;
    while (i < nums1.Length && j < nums2.Length)
    {
      if (nums1[i] <= nums2[j])
      {
        max = Math.Max(max, j - i);
        j++;
      }
      else
      {
        if (i >= j) { j++; } // to ensure always j >= i
        i++;
      }
    }
    return max;
  }
}