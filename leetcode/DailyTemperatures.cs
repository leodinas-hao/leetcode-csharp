/*
daily temperatures
https://leetcode.com/problems/daily-temperatures/

Given an array of integers temperatures represents the daily temperatures, 
return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. 
If there is no future day for which this is possible, keep answer[i] == 0 instead.

Example 1:
Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]

Example 2:
Input: temperatures = [30,40,50,60]
Output: [1,1,1,0]

Example 3:
Input: temperatures = [30,60,90]
Output: [1,1,0]

Constraints:
1 <= temperatures.length <= 10^5
30 <= temperatures[i] <= 100
*/

namespace LeetCode.DailyTemperatures;

public class Solution
{
  public int[] DailyTemperatures(int[] temperatures)
  {
    int len = temperatures.Length;
    int[] ans = new int[len];
    Stack<int> stack = new Stack<int>();
    for (int today = 0; today < len; today++)
    {
      // pop until the current day's temperature is lower
      // than the temperature at the top of the stack
      while (stack.Any() && temperatures[stack.Peek()] < temperatures[today])
      {
        // today's temperature is higher than the previous day
        int prevDay = stack.Pop();
        // update the answer list
        ans[prevDay] = today - prevDay;
      }
      stack.Push(today);
    }
    return ans;
  }
}