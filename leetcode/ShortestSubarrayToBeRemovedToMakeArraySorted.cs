/*
Shortest Subarray to be Removed to Make Array Sorted

Given an integer array arr, remove a subarray (can be empty) from arr such that the remaining elements in arr are non-decreasing.
Return the length of the shortest subarray to remove.
A subarray is a contiguous subsequence of the array.

Example 1:
Input: arr = [1,2,3,10,4,2,3,5]
Output: 3
Explanation: The shortest subarray we can remove is [10,4,2] of length 3. 
The remaining elements after that will be [1,2,3,3,5] which are sorted.
Another correct solution is to remove the subarray [3,10,4].

Example 2:
Input: arr = [5,4,3,2,1]
Output: 4
Explanation: Since the array is strictly decreasing, we can only keep a single element. 
Therefore we need to remove a subarray of length 4, either [5,4,3,2] or [4,3,2,1].

Example 3:
Input: arr = [1,2,3]
Output: 0
Explanation: The array is already non-decreasing. We do not need to remove any elements.

Constraints:
1 <= arr.length <= 10^5
0 <= arr[i] <= 10^9
*/

namespace LeetCode.ShortestSubarrayToBeRemovedToMakeArraySorted;

public class Solution
{
  public int FindLengthOfShortestSubarray(int[] arr)
  {
    int n = arr.Length;
    int start = 0;
    while (start < n - 1 && arr[start + 1] >= arr[start]) start++;
    // already non-decreasing
    if (start == n - 1) return 0;

    int end = n - 1;
    while (end >= 0 && arr[end - 1] <= arr[end]) end--;

    int ans = Math.Min(n - start - 1, end);
    int i = 0;
    while (i <= start && end < n)
    {
      if (arr[i] > arr[end]) end++;
      else
      {
        ans = Math.Min(ans, end - i - 1);
        i++;
      }
    }

    return ans;
  }
}