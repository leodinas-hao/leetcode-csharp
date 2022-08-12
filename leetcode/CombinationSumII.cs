/*
Combination Sum II
https://leetcode.com/problems/combination-sum-ii/

Given a collection of candidate numbers (candidates) and a target number (target), 
find all unique combinations in candidates where the candidate numbers sum to target.
Each number in candidates may only be used once in the combination.
Note: The solution set must not contain duplicate combinations.

Example 1:
Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[[1,1,6],[1,2,5],[1,7],[2,6]]

Example 2:
Input: candidates = [2,5,2,1,2], target = 5
Output: 
[[1,2,2],[5]]

Constraints:
1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30
*/

namespace LeetCode.CombinationSumII;

public class Solution
{
  private void Helper(int[] candidates, int target, int index, IList<int> comb, IList<IList<int>> output)
  {
    if (target == 0)
    {
      output.Add(new List<int>(comb));
      return;
    }

    for (int i = index; i < candidates.Length; i++)
    {
      // skip the same number to avoid duplicates
      if (i > index && candidates[i] == candidates[i - 1]) continue;

      var remain = target - candidates[i];
      if (remain < 0) break;

      comb.Add(candidates[i]);
      Helper(candidates, remain, i + 1, comb, output);
      comb.RemoveAt(comb.Count - 1);
    }
  }

  public IList<IList<int>> CombinationSum2(int[] candidates, int target)
  {
    var output = new List<IList<int>>();

    Array.Sort(candidates);

    Helper(candidates, target, 0, new List<int>(), output);
    return output;
  }
}