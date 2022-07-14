/*
Edit Distance
https://leetcode.com/problems/edit-distance/

Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

You have the following three operations permitted on a word:
Insert a character
Delete a character
Replace a character

Example 1:
Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')

Example 2:
Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')

Constraints:
0 <= word1.length, word2.length <= 500
word1 and word2 consist of lowercase English letters.
*/

namespace LeetCode.EditDistance;

public class Solution
{
  public int MinDistance(string word1, string word2)
  {
    int len1 = word1.Length, len2 = word2.Length;
    // dp[i,j] represents the minimum number of edits
    // required to get word1[..i] to match word2[..j]
    // consider below dp matrix for converting CAT to CUT
    // @ represents empty string or ""
    // | 0 | @ | C | U | T |
    // | @ | 0 | 1 | 2 | 3 |
    // | C | 1 | 0 | 1 | 2 |
    // | A | 2 | 1 | 1 | 2 |
    // | T | 3 | 2 | 2 | 1 |
    var dp = new int[len1 + 1, len2 + 1];

    for (int i = 0; i <= len1; i++)
    {
      for (int j = 0; j <= len2; j++)
      {
        if (i == 0) dp[i, j] = j;
        else if (j == 0) dp[i, j] = i;
        // no change required as both chars are the same
        else if (word1[i - 1] == word2[j - 1])
        {
          dp[i, j] = dp[i - 1, j - 1];
        }
        else
        {
          int insert = dp[i, j - 1];
          int delete = dp[i - 1, j];
          int replace = dp[i - 1, j - 1];
          dp[i, j] = 1 + Math.Min(insert, Math.Min(delete, replace));
        }
      }
    }

    return dp[len1, len2];
  }
}