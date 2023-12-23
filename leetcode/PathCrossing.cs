/*
Path Crossing
https://leetcode.com/problems/path-crossing/

Given a string path, where path[i] = 'N', 'S', 'E' or 'W', each representing moving one unit north, south, east, or west, respectively. 
You start at the origin (0, 0) on a 2D plane and walk on the path specified by path.

Return true if the path crosses itself at any point, that is, if at any time you are on a location you have previously visited. Return false otherwise.

Example 1:
     _
    | |
    *

Input: path = "NES"
Output: false 
Explanation: Notice that the path doesn't cross any point more than once.

Example 2:
     _
    | |
  --*--

Input: path = "NESWW"
Output: true
Explanation: Notice that the path visits the origin twice.

Constraints:
1 <= path.length <= 10^4
path[i] is either 'N', 'S', 'E', or 'W'.
*/

namespace LeetCode.PathCrossing;

public class Solution
{
  public bool IsPathCrossing(string path)
  {
    var x = 0;
    var y = 0;
    var visited = new HashSet<(int, int)>();
    visited.Add((x, y));
    foreach (var dir in path)
    {
      if (dir == 'N') y++;
      else if (dir == 'S') y--;
      else if (dir == 'E') x++;
      else if (dir == 'W') x--;
      if (visited.Contains((x, y))) return true;
      visited.Add((x, y));
    }
    return false;
  }
}
