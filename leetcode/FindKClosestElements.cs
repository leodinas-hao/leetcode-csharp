/*
Find K Closest Elements
https://leetcode.com/problems/find-k-closest-elements/

Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array. The result should also be sorted in ascending order.
An integer a is closer to x than an integer b if:

|a - x| < |b - x|, or
|a - x| == |b - x| and a < b

Example 1:
Input: arr = [1,2,3,4,5], k = 4, x = 3
Output: [1,2,3,4]

Example 2:
Input: arr = [1,2,3,4,5], k = 4, x = -1
Output: [1,2,3,4]

Constraints:
1 <= k <= arr.length
1 <= arr.length <= 10^4
arr is sorted in ascending order.
-10^4 <= arr[i], x <= 10^4
*/

namespace LeetCode.FindKClosestElements;

class ClosestComparer : Comparer<int>
{
  private int x;

  public ClosestComparer(int x)
  {
    this.x = x;
  }

  /*
   * Less than zero             a is less than b
   * Zero                       a equals b
   * Greater than zero          a is greater than b
   */
  public override int Compare(int a, int b)
  {
    if (Math.Abs(a - x) < Math.Abs(b - x)) return -1;
    else if (Math.Abs(a - x) == Math.Abs(b - x))
    {
      if (a < b) return -1;
      if (a == b) return 0;
    }
    return 1;
  }
}

public class Solution
{
  public IList<int> FindClosestElements(int[] arr, int k, int x)
  {
    // edge cases
    if (x <= arr[0]) return arr[0..k];
    if (x >= arr[^1]) return arr[^k..];
    // when x in the middle of the array
    var ls = arr.OrderBy(n => n, new ClosestComparer(x)).Take(k);
    return ls.OrderBy(n => n).ToList();
  }
}

public class Solution2
{
  public IList<int> FindClosestElements(int[] arr, int k, int x)
  {
    // edge cases
    if (x <= arr[0]) return arr[0..k];
    if (x >= arr[^1]) return arr[^k..];
    // when x in the middle of the array
    Array.Sort(arr, (int a, int b) =>
    {
      var diff = Math.Abs(a - x) - Math.Abs(b - x);
      if (diff < 0) return -1;
      else if (diff == 0)
      {
        if (a < b) return -1;
        if (a == b) return 0;
      }
      return 1;
    });
    return arr.Take(k).OrderBy(n => n).ToList();
  }
}
