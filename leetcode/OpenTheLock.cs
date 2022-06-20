/*
Open the Lock
https://leetcode.com/problems/open-the-lock/

You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. 
The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. 
Each move consists of turning one wheel one slot.

The lock initially starts at '0000', a string representing the state of the 4 wheels.

You are given a list of deadends dead ends, meaning if the lock displays any of these codes, 
the wheels of the lock will stop turning and you will be unable to open it.

Given a target representing the value of the wheels that will unlock the lock, 
return the minimum total number of turns required to open the lock, or -1 if it is impossible.

Example 1:
Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
Output: 6
Explanation: 
A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
because the wheels of the lock become stuck after the display becomes the dead end "0102".

Example 2:
Input: deadends = ["8888"], target = "0009"
Output: 1
Explanation: We can turn the last wheel in reverse to move from "0000" -> "0009".

Example 3:
Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
Output: -1
Explanation: We cannot reach the target without getting stuck.

Constraints:
1 <= deadends.length <= 500
deadends[i].length == 4
target.length == 4
target will not be in the list deadends.
target and deadends[i] consist of digits only.
*/

namespace LeetCode.OpenTheLock;

/*
helper class to present the wheel combination
*/
class Combination : IEquatable<Combination>
{
  int w1, w2, w3, w4;
  public Combination(int w1, int w2, int w3, int w4)
  {
    if (w1 >= 10 || w1 < 0 || w2 >= 10 || w2 < 0 || w3 >= 10 || w3 < 0 || w4 >= 10 || w4 < 0)
      throw new InvalidDataException();

    this.w1 = w1;
    this.w2 = w2;
    this.w3 = w3;
    this.w4 = w4;
  }

  public Combination[] Next()
  {
    // gets a list of all possible next combination
    var p1u = new Combination((w1 + 1) % 10, w2, w3, w4);
    var p1d = new Combination(w1 == 0 ? 9 : w1 - 1, w2, w3, w4);
    var p2u = new Combination(w1, (w2 + 1) % 10, w3, w4);
    var p2d = new Combination(w1, w2 == 0 ? 9 : w2 - 1, w3, w4);
    var p3u = new Combination(w1, w2, (w3 + 1) % 10, w4);
    var p3d = new Combination(w1, w2, w3 == 0 ? 9 : w3 - 1, w4);
    var p4u = new Combination(w1, w2, w3, (w4 + 1) % 10);
    var p4d = new Combination(w1, w2, w3, w4 == 0 ? 9 : w4 - 1);

    return new Combination[] {
      p1u, p1d,
      p2u, p2d,
      p3u, p3d,
      p4u, p4d,
    };
  }

  // define a value equality check
  public bool Equals(Combination? other)
  {
    if (other == null) return false;
    if (Object.ReferenceEquals(this, other)) return true;
    if (this.GetType() != other.GetType()) return false;

    return (other.w1 == w1 && other.w2 == w2 && other.w3 == w3 && other.w4 == w4);
  }

  public override int GetHashCode()
  {
    return (w1, w2, w3, w4).GetHashCode();
  }

  public override string ToString()
  {
    return $"{w1}{w2}{w3}{w4}";
  }
}

public class Solution
{
  public int OpenLock(string[] deadends, string target)
  {
    if (target == "0000") return 0;
    if (deadends.Contains("0000")) return -1;

    // BFS
    // queue format: Combination & step count
    var queue = new Queue<(Combination, int)>();
    queue.Enqueue((new Combination(0, 0, 0, 0), 0));
    var visited = new HashSet<Combination>();

    while (queue.Any())
    {
      (Combination c, int steps) = queue.Dequeue();

      // check if visited
      if (!visited.Add(c)) continue;

      // check if dead ends
      if (deadends.Contains(c.ToString())) continue;

      // check if it's the target
      if (target == c.ToString()) return steps;

      // queue up next moves
      foreach (var next in c.Next())
      {
        queue.Enqueue((next, steps + 1));
      }
    }
    return -1;
  }
}
