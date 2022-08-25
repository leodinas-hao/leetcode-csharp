/*
Valid Triangle Number
https://leetcode.com/problems/valid-triangle-number/

Given an integer array nums, return the number of triplets chosen from the array 
that can make triangles if we take them as side lengths of a triangle.

Example 1:
Input: nums = [2,2,3,4]
Output: 3
Explanation: Valid combinations are: 
2,3,4 (using the first 2)
2,3,4 (using the second 2)
2,2,3

Example 2:
Input: nums = [4,2,3,4]
Output: 4
 
Constraints:
1 <= nums.length <= 1000
0 <= nums[i] <= 1000
*/

namespace LeetCode.ValidTriangleNumber;

/*
brute force with 3 loops
O(n^3)
*/
public class Solution
{
  public int TriangleNumber(int[] nums)
  {
    int count = 0;
    for (int i = 0; i < nums.Length - 2; i++)
    {
      for (int j = i + 1; j < nums.Length - 1; j++)
      {
        for (int k = j + 1; k < nums.Length; k++)
        {
          if (nums[i] + nums[j] > nums[k]
            && nums[i] + nums[k] > nums[j]
            && nums[j] + nums[k] > nums[i])
            count++;
        }
      }
    }
    return count;
  }
}

/*
binary search
O(n^2 * log n)

sort the array so that `nums[i] <= nums[j] <= nums[k]` and if `nums[i] + nums[j] > nums[k]` then it's a triangle
*/
public class Solution2
{
  /*
  binary search to find the right limit of k (index of the longest side)
  */
  private int Search(int[] nums, int l, int r, int x)
  {
    while (r >= l && r < nums.Length)
    {
      int mid = (l + r) / 2;
      if (nums[mid] >= x) r = mid - 1;
      else l = mid + 1;
    }
    return l;
  }

  public int TriangleNumber(int[] nums)
  {
    int count = 0;
    Array.Sort(nums);
    for (int i = 0; i < nums.Length - 2; i++)
    {
      int k = i + 2;
      for (int j = i + 1; j < nums.Length - 1 && nums[i] != 0; j++)
      {
        k = Search(nums, k, nums.Length - 1, nums[i] + nums[j]);
        count += k - j - 1;
      }
    }
    return count;
  }
}

/*
linear scan
O(n^2)
*/
public class Solution3
{
  public int TriangleNumber(int[] nums)
  {
    int count = 0;
    Array.Sort(nums);

    for (int i = 0; i < nums.Length - 2; i++)
    {
      // k is the index of the longest side
      int k = i + 2;
      for (int j = i + 1; j < nums.Length - 1 && nums[i] != 0; j++)
      {
        while (k < nums.Length && nums[i] + nums[j] > nums[k]) k++;
        count += k - j - 1;
      }
    }

    return count;
  }
}