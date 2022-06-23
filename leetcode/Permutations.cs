/*
Permutations
https://leetcode.com/problems/permutations/

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [0,1]
Output: [[0,1],[1,0]]

Example 3:
Input: nums = [1]
Output: [[1]]

Constraints:
1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.
*/

namespace LeetCode.Permutations;

public class Solution
{
  private IList<IList<int>> permutes;

  private void Swap(int[] nums, int i, int j)
  {
    // swap nums[i] with nums[j]
    if (i != j)
    {
      int temp = nums[i];
      nums[i] = nums[j];
      nums[j] = temp;
    }
  }

  private void GeneratePermute(int[] nums, int index)
  {
    if (index == nums.Length)
    {
      // need to create new instance of the array before adding to list
      permutes.Add(new List<int>(nums));
      return;
    }
    for (int i = index; i < nums.Length; i++)
    {
      Swap(nums, i, index);
      GeneratePermute(nums, index + 1);
      Swap(nums, i, index);
    }
  }

  public IList<IList<int>> Permute(int[] nums)
  {
    permutes = new List<IList<int>>();
    GeneratePermute(nums, 0);
    return permutes;
  }
}
