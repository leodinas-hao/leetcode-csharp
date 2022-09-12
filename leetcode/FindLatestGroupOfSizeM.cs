/*
Find Latest Group of Size M
https://leetcode.com/problems/find-latest-group-of-size-m/

Given an array arr that represents a permutation of numbers from 1 to n.
You have a binary string of size n that initially has all its bits set to zero. 
At each step i (assuming both the binary string and arr are 1-indexed) from 1 to n, the bit at position arr[i] is set to 1.
You are also given an integer m. Find the latest step at which there exists a group of ones of length m. 
A group of ones is a contiguous substring of 1's such that it cannot be extended in either direction.
Return the latest step at which there exists a group of ones of length exactly m. If no such group exists, return -1.

Example 1:
Input: arr = [3,5,1,2,4], m = 1
Output: 4
Explanation: 
Step 1: "00100", groups: ["1"]
Step 2: "00101", groups: ["1", "1"]
Step 3: "10101", groups: ["1", "1", "1"]
Step 4: "11101", groups: ["111", "1"]
Step 5: "11111", groups: ["11111"]
The latest step at which there exists a group of size 1 is step 4.

Example 2:
Input: arr = [3,1,5,4,2], m = 2
Output: -1
Explanation: 
Step 1: "00100", groups: ["1"]
Step 2: "10100", groups: ["1", "1"]
Step 3: "10101", groups: ["1", "1", "1"]
Step 4: "10111", groups: ["1", "111"]
Step 5: "11111", groups: ["11111"]
No group of size 2 exists during any step.

Constraints:
n == arr.length
1 <= m <= n <= 10^5
1 <= arr[i] <= n
All integers in arr are distinct.
*/

namespace LeetCode.FindLatestGroupOfSizeM;


public class Solution0
{
  public int FindLatestStep(int[] arr, int m)
  {
    int n = arr.Length;
    if (m == n) return n;

    int ans = -1;

    // dict to store start & end index of 1's
    // add {startIndex,endIndex} to head, and {endIndex,startIndex} to tail
    Dictionary<int, int> head = new Dictionary<int, int>();
    Dictionary<int, int> tail = new Dictionary<int, int>();

    for (int i = 0; i < n; i++)
    {
      //arr[i] connect 2 string, merge then : end at arr[i]-1 and start at arr[i]+1
      if (head.ContainsKey(arr[i] + 1) && tail.ContainsKey(arr[i] - 1))
      {
        var start1 = tail[arr[i] - 1];
        var end1 = arr[i] - 1;
        var start2 = arr[i] + 1;
        var end2 = head[arr[i] + 1];

        tail.Remove(head[arr[i] + 1]);
        head.Remove(tail[arr[i] - 1]);
        head.Remove(arr[i] + 1);
        tail.Remove(arr[i] - 1);

        head.Add(start1, end2);
        tail.Add(end2, start1);

        if (end1 - start1 + 1 == m) ans = i;
        if (end2 - start2 + 1 == m) ans = i;
      }
      //merge arr[i] with string start at arr[i]+1
      else if (head.ContainsKey(arr[i] + 1))
      {
        var start2 = arr[i] + 1;
        var end2 = head[arr[i] + 1];

        tail.Remove(head[arr[i] + 1]);
        head.Remove(arr[i] + 1);

        head.Add(arr[i], end2);
        tail.Add(end2, arr[i]);

        if (end2 - start2 + 1 == m) ans = i;
      }
      //merge arr[i] with string end at arr[i]-1
      else if (tail.ContainsKey(arr[i] - 1))
      {
        var start1 = tail[arr[i] - 1];
        var end1 = arr[i] - 1;

        head.Remove(tail[arr[i] - 1]);
        tail.Remove(arr[i] - 1);

        tail.Add(arr[i], start1);
        head.Add(start1, arr[i]);

        if (end1 - start1 + 1 == m) ans = i;
      }
      else
      {
        head.Add(arr[i], arr[i]);
        tail.Add(arr[i], arr[i]);
      }
    }

    return ans;
  }
}

public class Solution
{
  public int FindLatestStep(int[] arr, int m)
  {
    int n = arr.Length;
    if (m == n) return n;

    int[] ranges = new int[n + 2];
    int ans = -1;

    for (int i = 0; i < n; i++)
    {
      int left = arr[i], right = arr[i];
      if (ranges[left - 1] > 0) left = ranges[left - 1];
      if (ranges[right + 1] > 0) right = ranges[right + 1];
      ranges[left] = right;
      ranges[right] = left;
      if (right - arr[i] == m || arr[i] - left == m) ans = i;
    }
    return ans;
  }
}


public class Solution1
{
  public int FindLatestStep(int[] arr, int m)
  {
    int n = arr.Length;
    if (m == n) return n;

    int ans = -1;
    int[] inverted = new int[n + 2];
    Array.Fill(inverted, 0);
    for (int i = 0; i < n; i++)
    {
      inverted[arr[i]] = i + 1;
    }
    inverted[0] = n + 1;
    inverted[^1] = n + 1;

    for (int i = 1; i < n - m + 2; i++)
    {
      bool check = true;
      for (int j = i; j < i + m; j++)
      {
        check = inverted[i - 1] > inverted[j] && inverted[i + m] > inverted[j];
        if (!check) break;
      }
      if (check && Math.Min(inverted[i - 1] - 1, inverted[i + m] - 1) > ans)
        ans = Math.Min(inverted[i - 1] - 1, inverted[i + m] - 1);
    }
    return ans;
  }
}

/*
time limit exceeded somehow on leetcode
however the same solution implemented in java has no such issue
*/
public class Solution2
{

  public int FindLatestStep(int[] arr, int m)
  {
    int n = arr.Length;
    if (m == n) return n;

    SortedSet<int> set = new SortedSet<int>();
    set.Add(0);
    set.Add(n + 1);

    for (int i = n - 1; i >= 0; i--)
    {
      // int left = set.Where(s => s <= arr[i]).Last();
      // int right = set.Where(s => s >= arr[i]).First();
      int left = set.GetViewBetween(Int32.MinValue, arr[i]).Max();
      int right = set.GetViewBetween(arr[i], Int32.MaxValue).Min();
      if (arr[i] - left - 1 == m || right - arr[i] - 1 == m) return i;
      set.Add(arr[i]);
    }
    return -1;
  }
}
