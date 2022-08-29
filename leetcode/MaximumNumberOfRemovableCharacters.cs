/*
Maximum Number of Removable Characters
https://leetcode.com/problems/maximum-number-of-removable-characters/?envType=study-plan&id=binary-search-ii

You are given two strings s and p where p is a subsequence of s. 
You are also given a distinct 0-indexed integer array removable containing a subset of indices of s (s is also 0-indexed).

You want to choose an integer k (0 <= k <= removable.length) such that, 
after removing k characters from s using the first k indices in removable, p is still a subsequence of s. 
More formally, you will mark the character at s[removable[i]] for each 0 <= i < k, 
then remove all marked characters and check if p is still a subsequence.

Return the maximum k you can choose such that p is still a subsequence of s after the removals.

A subsequence of a string is a new string generated from the original string 
with some characters (can be none) deleted without changing the relative order of the remaining characters.

Example 1:
Input: s = "abcacb", p = "ab", removable = [3,1,0]
Output: 2
Explanation: After removing the characters at indices 3 and 1, "abcacb" becomes "accb".
"ab" is a subsequence of "accb".
If we remove the characters at indices 3, 1, and 0, "abcacb" becomes "ccb", and "ab" is no longer a subsequence.
Hence, the maximum k is 2.

Example 2:
Input: s = "abcbddddd", p = "abcd", removable = [3,2,1,4,5,6]
Output: 1
Explanation: After removing the character at index 3, "abcbddddd" becomes "abcddddd".
"abcd" is a subsequence of "abcddddd".

Example 3:
Input: s = "abcab", p = "abc", removable = [0,1,2,3,4]
Output: 0
Explanation: If you remove the first index in the array removable, "abc" is no longer a subsequence.

Constraints:
1 <= p.length <= s.length <= 10^5
0 <= removable.length < s.length
0 <= removable[i] < s.length
p is a subsequence of s.
s and p both consist of lowercase English letters.
The elements in removable are distinct.
*/

namespace LeetCode.MaximumNumberOfRemovableCharacters;

/*
Time Limit Exceeded on LeetCode
However Solution2, which is the almost identical algorithm got accepted
assuming Linq `Contains` consumes more time?!
*/
public class Solution
{
  private bool ISSubSequence(string s, string p, IEnumerable<int> removable)
  {
    int si = 0, pi = 0;
    while (si < s.Length && pi < p.Length)
    {
      if (!removable.Contains(si) && s[si] == p[pi]) pi++;
      si++;
    }
    return pi == p.Length;
  }

  public int MaximumRemovals(string s, string p, int[] removable)
  {
    int lo = 0, hi = removable.Length;
    while (lo <= hi)
    {
      int mid = (lo + hi) / 2;
      if (ISSubSequence(s, p, removable.Take(mid))) lo = mid + 1;
      else hi = mid - 1;
    }
    return hi;
  }
}

public class Solution2
{
  private bool ISSubSequence(string s, string p)
  {
    int si = 0, pi = 0;
    while (si < s.Length && pi < p.Length)
    {
      if (s[si] == p[pi]) pi++;
      si++;
    }
    return pi == p.Length;
  }

  private string Remove(string s, IEnumerable<int> removable)
  {
    var chars = s.ToCharArray();
    foreach (var r in removable) chars[r] = ' ';
    return new String(chars);
  }

  public int MaximumRemovals(string s, string p, int[] removable)
  {
    int lo = 0, hi = removable.Length;
    while (lo <= hi)
    {
      int mid = (lo + hi) / 2;
      if (ISSubSequence(Remove(s, removable.Take(mid)), p)) lo = mid + 1;
      else hi = mid - 1;
    }
    return hi;
  }
}