/*
Number of Subsequences That Satisfy the Given Sum Condition
https://leetcode.com/problems/number-of-subsequences-that-satisfy-the-given-sum-condition/

You are given an array of integers nums and an integer target.

Return the number of non-empty subsequences of nums such that the sum of the minimum and maximum element 
on it is less or equal to target. Since the answer may be too large, return it modulo 10^9 + 7.

Example 1:
Input: nums = [3,5,6,7], target = 9
Output: 4
Explanation: There are 4 subsequences that satisfy the condition.
[3] -> Min value + max value <= target (3 + 3 <= 9)
[3,5] -> (3 + 5 <= 9)
[3,5,6] -> (3 + 6 <= 9)
[3,6] -> (3 + 6 <= 9)

Example 2:
Input: nums = [3,3,6,8], target = 10
Output: 6
Explanation: There are 6 subsequences that satisfy the condition. (nums can have repeated numbers).
[3] , [3] , [3,3], [3,6] , [3,6] , [3,3,6]

Example 3:
Input: nums = [2,3,3,4,6,7], target = 12
Output: 61
Explanation: There are 63 non-empty subsequences, two of them do not satisfy the condition ([6,7], [7]).
Number of valid subsequences (63 - 2 = 61).

Constraints:
1 <= nums.length <= 10^5
1 <= nums[i] <= 10^6
1 <= target <= 10^6
*/

namespace LeetCode.NumberOfSubsequencesThatSatisfyTheGivenSumCondition;

/*
following will give wrong answer when it's large answer due to number type overflow issue
*/
public class Solution
{
  public int NumSubseq(int[] nums, int target)
  {
    long ans = 0, mod = 1_000_000_007;
    Array.Sort(nums);

    int i = 0, j = nums.Length - 1;
    while (i <= j)
    {
      if (nums[i] + nums[j] <= target)
      {
        ans += (int)(Math.Pow(2, j - i) % mod);
        i++;
      }
      else j--;
    }
    return (int)(ans % mod);
  }
}


public class Solution2
{
  public int NumSubseq(int[] nums, int target)
  {
    int ans = 0, mod = 1_000_000_007;
    Array.Sort(nums);

    int[] dp = new int[nums.Length];
    dp[0] = 1;
    for (int i = 1; i < nums.Length; i++)
      dp[i] = (int)(2 * dp[i - 1] % mod);

    int lo = 0, hi = nums.Length - 1;
    while (lo <= hi)
    {
      if (nums[lo] + nums[hi] <= target)
      {
        ans = (int)((ans + dp[hi - lo]) % mod);
        lo++;
      }
      else
      {
        hi--;
      }
    }

    return ans;
  }
}