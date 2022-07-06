/*
Verifying an Alien Dictionary
https://leetcode.com/problems/verifying-an-alien-dictionary/

In an alien language, surprisingly, they also use English lowercase letters, 
but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

Given a sequence of words written in the alien language, and the order of the alphabet, 
return true if and only if the given words are sorted lexicographically in this alien language.

Example 1:
Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.

Example 2:
Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.

Example 3:
Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false
Explanation: The first three characters "app" match, and the second string is shorter (in size.) 
According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).

Constraints:
1 <= words.length <= 100
1 <= words[i].length <= 20
order.length == 26
All characters in words[i] and order are English lowercase letters.
*/

namespace LeetCode.VerifyingAnAlienDictionary;

/*
this is more like a practice of custom comparer
just to solve the question if the list is in order, no need a full comparer
*/

class AlienComparer : Comparer<string>
{
  private char[] map;

  public AlienComparer(string order)
  {
    map = order.ToCharArray();
  }

  /*
   * Less than zero             x is less than y
   * Zero                       x equals y
   * Greater than zero          x is greater than y
   */
  public override int Compare(string? x, string? y)
  {
    // null
    if (x == null && y == null) return 0;
    if (x == null) return 1;
    if (y == null) return -1;
    // blank string
    if (x.Length == 0 && y.Length > 0) return -1;
    if (x.Length > 0 && y.Length == 0) return 1;
    if (x.Length == 0 && y.Length == 0) return 0;

    // char by char compare
    for (int i = 0; i < x.Length; i++)
    {
      // x is longer than y
      if (i >= y.Length) return 1;
      // compare the char at ith position
      int xi = Array.IndexOf(map, x[i]);
      int yi = Array.IndexOf(map, y[i]);
      if (xi > yi) return 1;
      if (xi < yi) return -1;
    }
    return 0;
  }
}

public class Solution
{
  public bool IsAlienSorted(string[] words, string order)
  {
    var ordered = words.OrderBy((word) => word, new AlienComparer(order)).ToArray();
    for (int i = 0; i < words.Length; i++)
    {
      if (words[i] != ordered[i]) return false;
    }
    return true;
  }
}
