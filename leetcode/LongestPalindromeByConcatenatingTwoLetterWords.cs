/*
Longest Palindrome by Concatenating Two Letter Words
https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/

You are given an array of strings words. Each element of words consists of two lowercase English letters.
Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. 
Each element can be selected at most once.
Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.
A palindrome is a string that reads the same forward and backward.


Example 1:
Input: words = ["lc","cl","gg"]
Output: 6
Explanation: One longest palindrome is "lc" + "gg" + "cl" = "lcggcl", of length 6.
Note that "clgglc" is another longest palindrome that can be created.

Example 2:
Input: words = ["ab","ty","yt","lc","cl","ab"]
Output: 8
Explanation: One longest palindrome is "ty" + "lc" + "cl" + "yt" = "tylcclyt", of length 8.
Note that "lcyttycl" is another longest palindrome that can be created.

Example 3:
Input: words = ["cc","ll","xx"]
Output: 2
Explanation: One longest palindrome is "cc", of length 2.
Note that "ll" is another longest palindrome that can be created, and so is "xx".

Constraints:
1 <= words.length <= 10^5
words[i].length == 2
words[i] consists of lowercase English letters.
*/

namespace LeetCode.PalindromeByConcatenatingTwoLetterWords;

public class Solution
{
  public int LongestPalindrome(string[] words)
  {
    int ans = 0;
    var counter = new Dictionary<string, int>();
    // iterate the word list to find all pairs (words with reversed in the list)
    foreach (var w in words)
    {
      string reversed = $"{w[1]}{w[0]}";
      if (counter.ContainsKey(reversed))
      {
        ans += 4;
        counter[reversed]--;
        if (counter[reversed] == 0) counter.Remove(reversed);
        continue;
      }
      counter[w] = 1 + (counter.ContainsKey(w) ? counter[w] : 0);
    }
    // find a single "aa" case, which can be added to the center of the palindrome
    foreach (var w in counter.Keys)
    {
      if (counter[w] == 1 && w[0] == w[1])
      {
        ans += 2;
        break;
      }
    }
    return ans;
  }
}
