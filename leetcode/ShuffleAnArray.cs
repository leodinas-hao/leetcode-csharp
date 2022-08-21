/*
Shuffle an Array
https://leetcode.com/problems/shuffle-an-array/

Given an integer array nums, design an algorithm to randomly shuffle the array. 
All permutations of the array should be equally likely as a result of the shuffling.
Implement the Solution class:

Solution(int[] nums) Initializes the object with the integer array nums.
int[] reset() Resets the array to its original configuration and returns it.
int[] shuffle() Returns a random shuffling of the array.

Example 1:
Input
["Solution", "shuffle", "reset", "shuffle"]
[[[1, 2, 3]], [], [], []]
Output
[null, [3, 1, 2], [1, 2, 3], [1, 3, 2]]
Explanation
Solution solution = new Solution([1, 2, 3]);
solution.shuffle();    // Shuffle the array [1,2,3] and return its result.
                       // Any permutation of [1,2,3] must be equally likely to be returned.
                       // Example: return [3, 1, 2]
solution.reset();      // Resets the array back to its original configuration [1,2,3]. Return [1, 2, 3]
solution.shuffle();    // Returns the random shuffling of array [1,2,3]. Example: return [1, 3, 2]

Constraints:
1 <= nums.length <= 50
-10^6 <= nums[i] <= 10^6
All the elements of nums are unique.
At most 10^4 calls in total will be made to reset and shuffle.
*/

namespace LeetCode.ShuffleAnArray;

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */


public class Solution
{
  private int[] array;
  private int[] original;

  private Random random = new Random();

  private void Swap(int i, int j)
  {
    // swap ith item in array to j
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
  }

  public Solution(int[] nums)
  {
    array = nums;
    original = (int[])array.Clone();
  }

  public int[] Reset()
  {
    array = original;
    // take a copy of the ref ot `original` to avoid unexpected changes to `original` array
    original = (int[])array.Clone();
    return array;
  }

  public int[] Shuffle()
  {
    for (int i = 0; i < array.Length; i++)
    {
      Swap(i, random.Next(i, array.Length));
    }
    return array;
  }
}
