/*
Permutations II
https://leetcode.com/problems/permutations-ii/

Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

Example 1:
Input: nums = [1,1,2]
Output:
[[1,1,2],[1,2,1],[2,1,1]]

Example 2:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Constraints:
1 <= nums.length <= 8
-10 <= nums[i] <= 10
*/

namespace LeetCode.PermutationsII;

/*
backtracking
to avoid duplicates, put occupance of each number from the array into a dictionary
then build combinations out of the dictionary instead of the array
*/
public class Solution
{
  private IList<IList<int>> output;

  private void Helper(int len, Dictionary<int, int> counter, IList<int> comb)
  {
    if (comb.Count == len)
    {
      output.Add(new List<int>(comb));
      return;
    }

    // iterate the numbers(keys) in the counter to find all combinations
    foreach (var record in counter)
    {
      int n = record.Key, count = record.Value;
      if (count == 0) continue;

      // add the number to the current combination
      comb.Add(n);
      counter[n]--;

      // proceed to the next digit of the current combination
      Helper(len, counter, comb);

      // backtrack for next combination
      comb.RemoveAt(comb.Count - 1);
      counter[n]++;
    }
  }

  public IList<IList<int>> PermuteUnique(int[] nums)
  {
    output = new List<IList<int>>();
    // count the number of occurrence of each number
    var counter = new Dictionary<int, int>();
    foreach (int n in nums)
    {
      if (counter.ContainsKey(n)) counter[n]++;
      else counter.Add(n, 1);
    }

    Helper(nums.Length, counter, new List<int>());

    return output;
  }
}
