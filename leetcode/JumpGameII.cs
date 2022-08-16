/*
Jump Game II
https://leetcode.com/problems/jump-game-ii/

Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
Each element in the array represents your maximum jump length at that position.
Your goal is to reach the last index in the minimum number of jumps.
You can assume that you can always reach the last index.

Example 1:
Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [2,3,0,1,4]
Output: 2

Constraints:
1 <= nums.length <= 10^4
0 <= nums[i] <= 1000
*/

namespace LeetCode.JumpGameII;

/*
DP
starting from the last index and move backward alone the way to check the min steps taken
*/
public class Solution
{
  public int Jump(int[] nums)
  {
    int len = nums.Length;
    var steps = new int[len];
    // to avoid overflowing to negative numbers
    Array.Fill(steps, Int32.MaxValue - 1000);

    // update base case (last index)
    steps[len - 1] = 0;

    for (int i = len - 2; i >= 0; i--)
    {
      if (nums[i] > 0)
      {
        // get the reachable range
        Range range = (i + 1)..Math.Min(len, nums[i] + i + 1);
        // get the min steps within the range
        steps[i] = steps[range].Min() + 1;
      }
    }
    return steps[0];
  }
}

/*
BFS
*/
public class Solution2
{
  public int Jump(int[] nums)
  {
    var queue = new Queue<int>();
    queue.Enqueue(0);
    var visited = new HashSet<int>();
    visited.Add(0);

    int count = 0;
    while (queue.Any())
    {
      var len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        int pos = queue.Dequeue();
        if (pos == nums.Length - 1) return count;
        for (int p = 1; p <= nums[pos]; p++)
        {
          int next = p + pos;
          if (next < nums.Length)
          {
            if (!visited.Add(next)) continue;
            queue.Enqueue(next);
          }
        }
      }
      count++;
    }
    return count;
  }
}


/*
DP
starting from first index and moving alone the array to check the minimum steps taken
*/
public class Solution3
{
  public int Jump(int[] nums)
  {
    int len = nums.Length;
    var dp = new int[len];
    // base case
    dp[0] = 0;

    for (int i = 0; i < len; i++)
    {
      // update all the index moving forward based on the current max step value
      for (int j = i + 1; j <= nums[i] + i; j++)
      {
        if (j < len && dp[j] == 0) dp[j] = dp[i] + 1;
      }
    }

    return dp[^1];
  }
}
