/*
Find the distance value between two arrays
https://leetcode.com/problems/find-the-distance-value-between-two-arrays/

Given two integer arrays arr1 and arr2, and the integer d, return the distance value between the two arrays.
The distance value is defined as the number of elements arr1[i] such that there is not any element arr2[j] where |arr1[i]-arr2[j]| <= d.

Example 1:
Input: arr1 = [4,5,8], arr2 = [10,9,1,8], d = 2
Output: 2
Explanation: 
For arr1[0]=4 we have: 
|4-10|=6 > d=2 
|4-9|=5 > d=2 
|4-1|=3 > d=2 
|4-8|=4 > d=2 
For arr1[1]=5 we have: 
|5-10|=5 > d=2 
|5-9|=4 > d=2 
|5-1|=4 > d=2 
|5-8|=3 > d=2
For arr1[2]=8 we have:
|8-10|=2 <= d=2
|8-9|=1 <= d=2
|8-1|=7 > d=2
|8-8|=0 <= d=2

Example 2:
Input: arr1 = [1,4,2,3], arr2 = [-4,-3,6,10,20,30], d = 3
Output: 2

Example 3:
Input: arr1 = [2,1,100,3], arr2 = [-5,-2,10,-3,7], d = 6
Output: 1

Constraints:
1 <= arr1.length, arr2.length <= 500
-1000 <= arr1[i], arr2[j] <= 1000
0 <= d <= 100
*/

namespace LeetCode.FindTheDistanceValueBetweenTwoArrays;

public class Solution
{
  public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
  {
    int count = 0;
    // sort arr2 for binary search
    Array.Sort(arr2);
    foreach (int num in arr1)
    {
      bool distanceVal = true;
      // to ensure the distance value, find the lowest & highest values within the distance range
      int hi = num + d;
      int lo = num - d;

      // binary search arr2 to find if any value within the lo & hi range
      int left = 0, right = arr2.Length - 1;
      while (left <= right)
      {
        int mid = left + (right - left) / 2;
        if (arr2[mid] <= hi && arr2[mid] >= lo) { distanceVal = false; break; }
        else if (arr2[mid] > hi) right = mid - 1;
        else left = mid + 1;  // arr[mid] < lo
      }
      if (distanceVal) count++;
    }
    return count;
  }
}
