/*
Generate Parentheses
https://leetcode.com/problems/generate-parentheses/

Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:
Input: n = 1
Output: ["()"]

Constraints:
1 <= n <= 8
*/

namespace LeetCode.GenerateParentheses;

/*
DFS
*/
public class Solution
{
  private void Helper(int open, int close, int max, string curr, IList<string> output)
  {
    if (curr.Length == max * 2)
    {
      output.Add(curr);
      return;
    }

    // add opening bracket
    if (open < max) Helper(open + 1, close, max, curr + '(', output);
    // add close bracket
    if (close < open) Helper(open, close + 1, max, curr + ')', output);
  }

  public IList<string> GenerateParenthesis(int n)
  {
    var output = new List<string>();

    Helper(0, 0, n, "", output);

    return output;
  }
}
