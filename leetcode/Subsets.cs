/*
subsets
https://leetcode.com/problems/subsets/

Given an integer array nums of unique elements, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

Constraints:
1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.
*/

namespace LeetCode.Subsets;

/*
cascading
iterate each num in the array and cascade next num onto the existing subsets
time: O(N*2^N)
*/
public class Solution
{
  public IList<IList<int>> Subsets(int[] nums)
  {
    var ls = new List<IList<int>>();
    ls.Add(new List<int>());  // add empty set

    foreach (var n in nums)
    {
      var subsets = new List<IList<int>>();
      foreach (var curr in ls)
      {
        var temp = new List<int>(curr);
        temp.Add(n);
        subsets.Add(temp);
      }
      foreach (var curr in subsets)
      {
        ls.Add(curr);
      }
    }
    return ls;
  }
}

/*
backtracking
loop over the length of the array rather than the numbers
time: O(N*2^N)
*/
public class Solution2
{
  private IList<IList<int>> output;

  private void Helper(int first, int len, int[] nums, IList<int> ls)
  {
    // backtracking to find the combinations
    if (ls.Count == len)
    {
      // get to the required len of the new combination
      output.Add(new List<int>(ls));
      return;
    }
    for (int i = first; i < nums.Length; i++)
    {
      // add ith number into the current combination
      ls.Add(nums[i]);
      // next number
      Helper(i + 1, len, nums, ls);
      // backtrack
      ls.Remove(nums[i]);
    }
  }

  public IList<IList<int>> Subsets(int[] nums)
  {
    output = new List<IList<int>>();
    for (int i = 0; i <= nums.Length; i++)
    {
      Helper(0, i, nums, new List<int>());
    }
    return output;
  }
}

/*
bitmask
generate all binary bitmasks of length n; 
check each bit position if 1 put the num at the corresponding position into the list, otherwise skip
time: O(N*2^N)

to get a bitmask with `n` length of 0's: `Convert.ToString(Math.Pow(2,n), 2)[1..]`
to get a bitmask with `n` length of 1's: `Convert.ToString(Math.Pow(2,n+1)-1, 2)[1..]`
*/
public class Solution3
{
  public IList<IList<int>> Subsets(int[] nums)
  {
    var output = new List<IList<int>>();
    int n = nums.Length;

    for (int i = (int)Math.Pow(2, n); i < (int)Math.Pow(2, n + 1); i++)
    {
      // convert int to bit & removing the leading `1`
      string bitmask = Convert.ToString(i, 2)[1..];
      var curr = new List<int>();
      for (int j = 0; j < n; j++)
      {
        if (bitmask[j] == '1') curr.Add(nums[j]);
      }
      output.Add(curr);
    }

    return output;
  }
}