/*
subsets ii
https://leetcode.com/problems/subsets-ii/

Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:
Input: nums = [1,2,2]
Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

Constraints:
1 <= nums.length <= 10
-10 <= nums[i] <= 10
*/

namespace LeetCode.SubsetsII;

/*
backtracking
*/
public class Solution
{
  private IList<IList<int>> output;

  private void Helper(int index, int[] nums, IList<int> curr)
  {
    output.Add(new List<int>(curr));

    for (int i = index; i < nums.Length; i++)
    {
      // skip as it's the same value as previous
      if (i != index && nums[i] == nums[i - 1]) continue;
      curr.Add(nums[i]);
      Helper(i + 1, nums, curr);
      curr.RemoveAt(curr.Count - 1);
    }
  }

  public IList<IList<int>> SubsetsWithDup(int[] nums)
  {
    output = new List<IList<int>>();

    // sort the array to ensure duplicate check in `Helper` works
    Array.Sort(nums);

    Helper(0, nums, new List<int>());

    return output;
  }
}

/*
bitmask to get combinations
*/
public class Solution2
{
  public IList<IList<int>> SubsetsWithDup(int[] nums)
  {
    Array.Sort(nums);
    var output = new List<IList<int>>();
    int n = nums.Length;
    int lo = (int)Math.Pow(2, n), hi = (int)Math.Pow(2, n + 1);

    for (int i = lo; i < hi; i++)
    {
      string bitmask = Convert.ToString(i, 2)[1..];
      var curr = new List<int>();

      for (int j = 0; j < n; j++)
      {
        if (bitmask[j] == '1') curr.Add(nums[j]);
      }

      if (!output.Any(l => l.SequenceEqual(curr))) output.Add(curr);
    }

    return output;
  }
}