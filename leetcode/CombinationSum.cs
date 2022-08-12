/*
Combination Sum
https://leetcode.com/problems/combination-sum/

Given an array of distinct integers candidates and a target integer target, 
return a list of all unique combinations of candidates where the chosen numbers sum to target. 
You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. 
Two combinations are unique if the frequency of at least one of the chosen numbers is different.

It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

Example 1:
Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.

Example 2:
Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]

Example 3:
Input: candidates = [2], target = 1
Output: []

Constraints:
1 <= candidates.length <= 30
1 <= candidates[i] <= 200
All elements of candidates are distinct.
1 <= target <= 500
*/

namespace LeetCode.CombinationSum;

public class Solution
{
  private void Helper(int[] candidates, int target, int index, IList<int> curr, IList<IList<int>> output)
  {
    if (target == 0)
    {
      output.Add(new List<int>(curr));
      return;
    }

    if (target < 0 || index >= candidates.Length) return;

    // take the number at the index
    curr.Add(candidates[index]);
    Helper(candidates, target - candidates[index], index, curr, output);
    // backtracking
    curr.RemoveAt(curr.Count - 1);

    // take the next number (index+1)
    Helper(candidates, target, index + 1, curr, output);
  }

  public IList<IList<int>> CombinationSum(int[] candidates, int target)
  {
    var output = new List<IList<int>>();

    Helper(candidates, target, 0, new List<int>(), output);

    return output;
  }
}