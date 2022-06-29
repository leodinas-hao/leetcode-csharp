/*
Jump Game
https://leetcode.com/problems/jump-game/

You are given an integer array nums. You are initially positioned at the array's first index, 
and each element in the array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

Example 1:
Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

Constraints:
1 <= nums.length <= 10^4
0 <= nums[i] <= 10^5
*/

namespace LeetCode.JumpGame;

/*
check max move possible each step until the end & compare if max move can reach the current position
*/
public class Solution
{
  public bool CanJump(int[] nums)
  {
    int k = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
      // i already beyond the max move
      if (i > k) return false;
      // update the max move
      k = Math.Max(k, i + nums[i]);
    }
    return true;
  }
}

/*
BFS
Time Limit Exceeded on large input
*/
public class Solution2
{
  public bool CanJump(int[] nums)
  {
    var queue = new Queue<int>();
    queue.Enqueue(0);
    var visited = new HashSet<int>();
    visited.Add(0);

    while (queue.Any())
    {
      var len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        int pos = queue.Dequeue();
        if (pos == nums.Length - 1) return true;
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
    }
    return false;
  }
}
