/*
Water and Jug Problem
https://leetcode.com/problems/water-and-jug-problem/

You are given two jugs with capacities jug1Capacity and jug2Capacity liters. There is an infinite amount of water supply available. 
Determine whether it is possible to measure exactly targetCapacity liters using these two jugs.
If targetCapacity liters of water are measurable, you must have targetCapacity liters of water contained within one or both buckets by the end.

Operations allowed:
Fill any of the jugs with water.
Empty any of the jugs.
Pour water from one jug into another till the other jug is completely full, or the first jug itself is empty.

Example 1:
Input: jug1Capacity = 3, jug2Capacity = 5, targetCapacity = 4
Output: true
Explanation: The famous Die Hard example 

Example 2:
Input: jug1Capacity = 2, jug2Capacity = 6, targetCapacity = 5
Output: false

Example 3:
Input: jug1Capacity = 1, jug2Capacity = 2, targetCapacity = 3
Output: true

Constraints:
1 <= jug1Capacity, jug2Capacity, targetCapacity <= 10^6
*/

namespace LeetCode.WaterAndJugProblem;

/*
Greatest common divisor/math solution
*/
public class Solution2
{
  public static int GreatestCommonDivisor(int x, int y)
  {
    return y == 0 ? x : GreatestCommonDivisor(y, x % y);
  }

  public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
  {
    if (jug1Capacity + jug2Capacity < targetCapacity) return false;
    if (targetCapacity == 0 || jug1Capacity + jug2Capacity == targetCapacity) return true;

    return targetCapacity % GreatestCommonDivisor(jug1Capacity, jug2Capacity) == 0;
  }
}

/*
BFS
further optimization could be done to improve the performance
*/
public class Solution
{
  public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
  {
    // no solution if target is larger than the total capacity of 2 jugs
    if (jug1Capacity + jug2Capacity < targetCapacity) return false;
    // no solution if target is odd number, but capacities of 2 jugs are both even numbers
    if (targetCapacity % 2 != 0 && (jug1Capacity % 2 == 0 && jug2Capacity % 2 == 0)) return false;
    if (targetCapacity == 0 || jug1Capacity + jug2Capacity == targetCapacity) return true;

    // BFS
    // Tuple to represent the water in the jugs & previous states to avoid revisiting
    // first int represents jug1, second int represents jug2, last list caches previous states
    var queue = new Queue<(int, int, List<(int, int)>)>();
    // starting by filling jug 1 or jug 2
    queue.Enqueue((jug1Capacity, 0, new List<(int, int)> { (0, 0), (jug1Capacity, 0) }));
    queue.Enqueue((0, jug2Capacity, new List<(int, int)> { (0, 0), (0, jug2Capacity) }));

    int j1, j2, j1Next, j2Next, len;
    List<(int, int)> caches;

    while (queue.Any())
    {
      len = queue.Count;
      for (int i = 0; i < len; i++)
      {
        (j1, j2, caches) = queue.Dequeue();

        // solution identified
        if (j1 == targetCapacity || j2 == targetCapacity || (j1 + j2) == targetCapacity)
          return true;

        // next operation
        // fill jug1/jug2
        if (j1 < jug1Capacity && !caches.Contains((jug1Capacity, j2)))
        {
          caches.Add((jug1Capacity, j2));
          queue.Enqueue((jug1Capacity, j2, caches));
        }
        if (j2 < jug2Capacity && !caches.Contains((j1, jug2Capacity)))
        {
          caches.Add((j1, jug2Capacity));
          queue.Enqueue((j1, jug2Capacity, caches));
        }
        // empty jug1/jug2
        if (j1 > 0 && !caches.Contains((0, j2)))
        {
          caches.Add((0, j2));
          queue.Enqueue((0, j2, caches));
        }
        if (j2 > 0 && !caches.Contains((j1, 0)))
        {
          caches.Add((j1, 0));
          queue.Enqueue((j1, 0, caches));
        }
        // pour water from a jug to another (a jug is empty or another is full)
        // pour into jug1
        if (j2 > 0 && j1 < jug1Capacity)
        {
          if (j1 + j2 > jug1Capacity)
          {
            j1Next = jug1Capacity;
            j2Next = j1 + j2 - jug1Capacity;
          }
          else
          {
            j1Next = j1 + j2;
            j2Next = 0;
          }
          if (!caches.Contains((j1Next, j2Next)))
          {
            caches.Add((j1Next, j2Next));
            queue.Enqueue((j1Next, j2Next, caches));
          }
        }
        // pour into jug2
        if (j1 > 0 && j2 < jug2Capacity)
        {
          if (j1 + j2 > jug2Capacity)
          {
            j1Next = j1 + j2 - jug2Capacity;
            j2Next = jug2Capacity;
          }
          else
          {
            j1Next = 0;
            j2Next = j1 + j2;
          }
          if (!caches.Contains((j1Next, j2Next)))
          {
            caches.Add((j1Next, j2Next));
            queue.Enqueue((j1Next, j2Next, caches));
          }
        }
      }
    }

    return false;
  }
}