/*
Possible Bipartition
https://leetcode.com/problems/possible-bipartition/

We want to split a group of n people (labeled from 1 to n) into two groups of any size. 
Each person may dislike some other people, and they should not go into the same group.

Given the integer n and the array dislikes where dislikes[i] = [ai, bi] indicates that the person labeled ai does not like the person labeled bi, 
return true if it is possible to split everyone into two groups in this way.

Example 1:
Input: n = 4, dislikes = [[1,2],[1,3],[2,4]]
Output: true
Explanation: group1 [1,4] and group2 [2,3].

Example 2:
Input: n = 3, dislikes = [[1,2],[1,3],[2,3]]
Output: false

Example 3:
Input: n = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
Output: false

Constraints:
1 <= n <= 2000
0 <= dislikes.length <= 10^4
dislikes[i].length == 2
1 <= dislikes[i][j] <= n
ai < bi
All the pairs of dislikes are unique.
*/

namespace LeetCode.PossibleBipartition;

public class Solution
{
  private ValueTuple<int, bool> CheckColor(int p, int[] colors)
  {
    bool color = true;
    while (colors[p] != p)
    {
      p = colors[p];
      color = !color;
    }
    return (p, color);
  }

  public bool PossibleBipartition(int n, int[][] dislikes)
  {
    var colors = new int[n + 1];
    for (int i = 1; i <= n; i++) colors[i] = i;

    foreach (var dislike in dislikes)
    {
      int p1 = dislike[0], p2 = dislike[1];
      if (colors[p2] == p2) colors[p2] = p1;
      else
      {
        var check1 = CheckColor(p1, colors);
        var check2 = CheckColor(p2, colors);
        if (check1.Item1 == check2.Item1 && check1.Item2 == check2.Item2) return false;
      }
    }
    return true;
  }
}

/*
DFS
*/
public class Solution2
{
  private bool Helper(int[,] graph, int[] colors, int i, int color)
  {
    colors[i] = color;
    for (int j = 0; j < colors.Length; j++)
    {
      if (graph[i, j] == 1)
      {
        // disliked one already taken the same color
        if (colors[j] == color) return false;
        // disliked one not assigned any color yet
        // so check if the disliked one can be given a different color
        if (colors[j] == 0 && !Helper(graph, colors, j, -color)) return false;
      }
    }
    return true;
  }

  public bool PossibleBipartition(int n, int[][] dislikes)
  {
    int[,] graph = new int[n, n];
    foreach (var dislike in dislikes)
    {
      graph[dislike[0] - 1, dislike[1] - 1] = 1;
      graph[dislike[1] - 1, dislike[0] - 1] = 1;
    }

    int[] colors = new int[n];
    for (int i = 0; i < n; i++)
    {
      if (colors[i] == 0 && !Helper(graph, colors, i, 1))
        return false;
    }
    return true;
  }
}
