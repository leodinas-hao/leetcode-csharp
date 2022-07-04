/*
Trapping Rain Water
https://leetcode.com/problems/trapping-rain-water/

Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

Example 1:
^
|
|               #
|       # O O O # # O #
|   # O # # O # # # # # #
----------------------------->

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (# section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (O section) are being trapped.

Example 2:
Input: height = [4,2,0,3,2,5]
Output: 9

Constraints:
n == height.length
1 <= n <= 2 * 10^4
0 <= height[i] <= 10^5
*/

namespace LeetCode.TrappingRainWater;


/*
DP: maintain a left & right max in dp array
*/
public class Solution
{
  public int Trap(int[] height)
  {
    if (height.Length <= 1) return 0;

    int ans = 0, n = height.Length;
    int[] leftMax = new int[n];
    leftMax[0] = height[0];
    for (int i = 1; i < n; i++)
    {
      leftMax[i] = Math.Max(height[i], leftMax[i - 1]);
    }

    int[] rightMax = new int[n];
    rightMax[^1] = height[^1];
    for (int i = n - 2; i >= 0; i--)
    {
      rightMax[i] = Math.Max(height[i], rightMax[i + 1]);
    }

    // same logics here as brute force
    // as left & right max already captured in array
    // no need to calculate the max in-flight
    for (int i = 0; i < n; i++)
    {
      ans += (Math.Min(leftMax[i], rightMax[i]) - height[i]);
    }
    return ans;
  }
}

/*
two pointers
*/
public class Solution2
{
  public int Trap(int[] height)
  {
    int left = 0, right = height.Length - 1;
    int leftMax = 0, rightMax = 0, ans = 0;
    while (left < right)
    {
      if (height[left] < height[right])
      {
        if (height[left] >= leftMax) leftMax = height[left];
        else ans += leftMax - height[left];
        left++;
      }
      else
      {
        if (height[right] >= rightMax) rightMax = height[right];
        else ans += rightMax - height[right];
        right--;
      }
    }
    return ans;
  }
}

/*
brute force
Time limit exceeded on LeetCode when processing large inputs
*/
public class Solution3
{
  public int Trap(int[] height)
  {
    int ans = 0;
    for (int i = 0; i < height.Length; i++)
    {
      int leftMax = height[..(i + 1)].Max();
      int rightMax = height[i..].Max();
      ans += (Math.Min(leftMax, rightMax) - height[i]);
    }
    return ans;
  }
}





