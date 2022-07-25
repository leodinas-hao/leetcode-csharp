/*
Next Greater Element II
https://leetcode.com/problems/next-greater-element-ii/

Given a circular integer array nums (i.e., the next element of nums[nums.length - 1] is nums[0]), 
return the next greater number for every element in nums.

The next greater number of a number x is the first greater number to its traversing-order next in the array, 
which means you could search circularly to find its next greater number. If it doesn't exist, return -1 for this number.

Example 1:
Input: nums = [1,2,1]
Output: [2,-1,2]
Explanation: The first 1's next greater number is 2; 
The number 2 can't find next greater number. 
The second 1's next greater number needs to search circularly, which is also 2.

Example 2:
Input: nums = [1,2,3,4,3]
Output: [2,3,4,-1,4]

Constraints:
1 <= nums.length <= 10^4
-10^9 <= nums[i] <= 10^9
*/

namespace LeetCode.NextGreaterElementII;

/*
brute force
*/
public class Solution
{
  public int[] NextGreaterElements(int[] nums)
  {
    var result = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
      result[i] = -1;
      for (int j = 1; j < nums.Length; j++)
      {
        if (nums[(i + j) % nums.Length] > nums[i])
        {
          result[i] = nums[(i + j) % nums.Length];
          break;
        }
      }
    }

    return result;
  }
}


/*
use a stack to store the indices of the appropriate elements from nums array
the top of the stack refers to the index of the Next Greater Element found so far

similar approach to LeetCode.DailyTemperatures
*/
public class Solution2
{
  public int[] NextGreaterElements(int[] nums)
  {
    var result = new int[nums.Length];
    var stack = new Stack<int>();
    for (int i = 2 * nums.Length - 1; i >= 0; i--)
    {
      while (stack.Any() && nums[stack.Peek()] <= nums[i % nums.Length])
      {
        // pop the stack until the top element is greater than the current element
        stack.Pop();
      }
      // if the stack is not empty, the current element is the next greater element
      result[i % nums.Length] = stack.Any() ? nums[stack.Peek()] : -1;
      stack.Push(i % nums.Length);
    }

    return result;
  }
}
