/*
Partition Equal Subset Sum
https://leetcode.com/problems/partition-equal-subset-sum/

Given a non-empty array nums containing only positive integers, 
find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Example 1:
Input: nums = [1,5,11,5]
Output: true
Explanation: The array can be partitioned as [1, 5, 5] and [11].

Example 2:
Input: nums = [1,2,3,5]
Output: false
Explanation: The array cannot be partitioned into equal sum subsets.

Constraints:
1 <= nums.length <= 200
1 <= nums[i] <= 100
*/

namespace LeetCode.PartitionEqualSubsetSum;

public class Solution
{
  public bool CanPartition(int[] nums)
  {
    int sum = nums.Sum();
    // odd total can't be split into 2 equal parts
    if (sum % 2 == 1) return false;

    sum = sum / 2;
    bool[] dp = new bool[sum + 1];
    dp[0] = true;
    for (int i = 1; i < nums.Length; i++)
    {
      for (int j = sum; j >= nums[i - 1]; j--)
      {
        dp[j] = dp[j] || dp[j - nums[i - 1]];
      }
    }
    return dp[sum];
  }
}
