/*
Word break
https://leetcode.com/problems/word-break/

Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.
Note that the same word in the dictionary may be reused multiple times in the segmentation.

Example 1:
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false

Constraints:
1 <= s.length <= 300
1 <= wordDict.length <= 1000
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
All the strings of wordDict are unique.
*/

namespace LeetCode.WordBreak;

/*
DP
*/
public class Solution
{
  public bool WordBreak(string s, IList<string> wordDict)
  {
    int n = s.Length;

    // dp[i] indicates if s[0..i] can be formed by dict
    bool[] dp = new bool[n];

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j <= i; j++)
      {
        // take out sub string as s[j..(i+1)]
        // string sub = s.Substring(j, i - j + 1);
        string sub = new string(s[j..(i + 1)]);
        // current sub string found in dict && the sub string prior current sub string found match as well
        if (wordDict.Contains(sub) && (j == 0 || dp[j - 1]))
        {
          dp[i] = true;
          break;
        }
      }
    }
    return dp[n - 1];
  }
}