/*
Combinations
https://leetcode.com/problems/combinations/

Given two integers n and k, return all possible combinations of k numbers out of the range [1, n].
You may return the answer in any order.

Example 1:
Input: n = 4, k = 2
Output:
[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]

Example 2:
Input: n = 1, k = 1
Output: [[1]]

Constraints:
1 <= n <= 20
1 <= k <= n
*/

namespace LeetCode.Combinations;

/*
backtracking
*/
public class Solution
{
  private void permutate(int n, int k, int index, Stack<int> curr, IList<IList<int>> combinations)
  {
    if (curr.Count == k)
    {
      combinations.Add(new List<int>(curr));
      return;
    }

    for (int i = index; i <= n; i++)
    {
      curr.Push(i);
      permutate(n, k, i + 1, curr, combinations);
      curr.Pop();
    }
  }

  public IList<IList<int>> Combine(int n, int k)
  {
    var combinations = new List<IList<int>>();

    permutate(n, k, 1, new Stack<int>(), combinations);

    return combinations;
  }
}
