/*
Top K Frequent Elements
https://leetcode.com/problems/top-k-frequent-elements/

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:
Input: nums = [1], k = 1
Output: [1]

Constraints:

1 <= nums.length <= 105
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.
*/

namespace LeetCode.TopKFrequentElements;

public class Solution
{
  public int[] TopKFrequent(int[] nums, int k)
  {
    // create a dictionary to store the number as key and it's frequency as value
    Dictionary<int, int> counts = new Dictionary<int, int>();
    foreach (int n in nums)
    {
      if (counts.ContainsKey(n)) counts[n] += 1;
      else counts.Add(n, 1);
    }
    // convert the dict to an ordered list by value
    var list = counts.AsEnumerable().OrderByDescending((p) => p.Value);
    // pick the top k item from list
    return list.Take(k).Select((p) => p.Key).ToArray();
  }
}
