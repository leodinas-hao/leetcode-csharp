/*
Minimum jumps to reach home
https://leetcode.com/problems/minimum-jumps-to-reach-home/

A certain bug's home is on the x-axis at position x. Help them get there from position 0.

The bug jumps according to the following rules:

It can jump exactly a positions forward (to the right).
It can jump exactly b positions backward (to the left).
It cannot jump backward twice in a row.
It cannot jump to any forbidden positions.
The bug may jump forward beyond its home, but it cannot jump to positions numbered with negative integers.

Given an array of integers forbidden, where forbidden[i] means that the bug cannot jump to the position forbidden[i], and integers a, b, and x, 
return the minimum number of jumps needed for the bug to reach its home. If there is no possible sequence of jumps that lands the bug on position x, return -1.


Example 1:
Input: forbidden = [14,4,18,1,15], a = 3, b = 15, x = 9
Output: 3
Explanation: 3 jumps forward (0 -> 3 -> 6 -> 9) will get the bug home.

Example 2:
Input: forbidden = [8,3,16,6,12,20], a = 15, b = 13, x = 11
Output: -1

Example 3:
Input: forbidden = [1,6,2,14,5,17,4], a = 16, b = 9, x = 7
Output: 2
Explanation: One jump forward (0 -> 16) then one jump backward (16 -> 7) will get the bug home.

Constraints:
1 <= forbidden.length <= 1000
1 <= a, b, forbidden[i] <= 2000
0 <= x <= 2000
All the elements in forbidden are distinct.
Position x is not forbidden.
*/

namespace LeetCode.MinimumJumpsToReachHome;

/**
this solution keeps getting "Time Limit Exceeded" on LeetCode
not sure how to improve further :(
*/
public class Solution
{
  public int MinimumJumps(int[] forbidden, int a, int b, int x)
  {
    // a edge case where a == b & x % a != 0, then there is no solution
    if (a == b && x % a != 0) return -1;

    // farthest to reach
    int max = a + b + Math.Max(x, forbidden.Max());

    // assign b direction
    b = b * -1;

    // track a list of positions visited before to avoid revisit
    // visited format like: (current_pos, next_move[+a|-b])
    var visited = new List<Tuple<int, int>>();
    // add all forbidden positions
    foreach (var f in forbidden)
    {
      visited.Add(new Tuple<int, int>(f - a, a));
      visited.Add(new Tuple<int, int>(f + b, b));
    }

    // the queue with int Tuple like this: (current_pos, next_move[+a|-b])
    var queue = new Queue<Tuple<int, int>>();
    int count = 0;
    // queue first step as only can move forward
    queue.Enqueue(new Tuple<int, int>(0, a));

    while (queue.Any())
    {
      count++;
      int len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        var jump = queue.Dequeue();
        var pos = jump.Item1 + jump.Item2;
        if (pos == x) return count;
        if (visited.Contains(jump) || pos < 0 || pos > max)
        {
          continue;
        }
        else
        {
          // add visit to avoid revisit
          visited.Add(jump);

          // try move forward
          if (pos + a < max)
          {
            queue.Enqueue(new Tuple<int, int>(pos, a));
          }
          // try move backward (cannot move back twice in a row)
          if (jump.Item2 > 0)
          {
            queue.Enqueue(new Tuple<int, int>(pos, b));
          }
        }
      }
    }

    return -1;
  }
}
