/*
Set Mismatch
https://leetcode.com/problems/set-mismatch/

You have a set of integers s, which originally contains all the numbers from 1 to n. U
nfortunately, due to some error, one of the numbers in s got duplicated to another number in the set, which results in repetition of one number and loss of another number.
You are given an integer array nums representing the data status of this set after the error.
Find the number that occurs twice and the number that is missing and return them in the form of an array.

Example 1:
Input: nums = [1,2,2,4]
Output: [2,3]

Example 2:
Input: nums = [1,1]
Output: [1,2]

Constraints:
2 <= nums.length <= 10^4
1 <= nums[i] <= 10^4
*/

namespace LeetCode.SetMismatch;

public class Solution
{
  public int[] FindErrorNums(int[] nums)
  {
    var map = new Dictionary<int, int>();
    int duplicate = 0, missing = 0;
    foreach (int n in nums)
    {
      map[n] = 1 + (map.ContainsKey(n) ? map[n] : 0);
    }
    for (int i = 1; i <= nums.Length; i++)
    {
      if (!map.ContainsKey(i)) missing = i;
      else if (map[i] > 1) duplicate = i;
    }
    return new int[] { duplicate, missing };
  }
}
