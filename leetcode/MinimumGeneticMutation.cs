/*
Minimum Genetic Mutation
https://leetcode.com/problems/minimum-genetic-mutation/

A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.

Suppose we need to investigate a mutation from a gene string start to a gene string end 
where one mutation is defined as one single character changed in the gene string.

For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
There is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it a valid gene string.

Given the two gene strings start and end and the gene bank bank, return the minimum number of mutations needed 
to mutate from start to end. If there is no such a mutation, return -1.

Note that the starting point is assumed to be valid, so it might not be included in the bank.


Example 1:
Input: start = "AACCGGTT", end = "AACCGGTA", bank = ["AACCGGTA"]
Output: 1

Example 2:
Input: start = "AACCGGTT", end = "AAACGGTA", bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
Output: 2

Example 3:
Input: start = "AAAAACCC", end = "AACCCCCC", bank = ["AAAACCCC","AAACCCCC","AACCCCCC"]
Output: 3

Constraints:
start.length == 8
end.length == 8
0 <= bank.length <= 10
bank[i].length == 8
start, end, and bank[i] consist of only the characters ['A', 'C', 'G', 'T'].
*/

namespace LeetCode.MinimumGeneticMutation;

public class Solution
{
  public const int LEN = 8;
  private bool IsMutation(string gene, string mutation)
  {
    var diff = 0;
    for (int i = 0; i < LEN; i++)
    {
      if (diff > 1) return false;
      diff += gene[i] == mutation[i] ? 0 : 1;
    }
    return diff == 1;
  }

  public int MinMutation(string start, string end, string[] bank)
  {
    // no solution as `end` is not valid/not in bank
    if (!bank.Contains(end)) return -1;

    var queue = new Queue<string>();
    queue.Enqueue(start);
    var visited = new HashSet<string>();
    visited.Add(start);

    int count = 0;

    while (queue.Any())
    {
      var len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        var gene = queue.Dequeue();
        if (gene == end) return count;

        foreach (var m in bank)
        {
          if (IsMutation(gene, m))
          {
            if (!visited.Add(m)) continue;
            queue.Enqueue(m);
          }
        }
      }
      count++;
    }

    return -1;
  }
}