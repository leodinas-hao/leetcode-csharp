/*
Delete Operation for Two Strings
https://leetcode.com/problems/delete-operation-for-two-strings/

Given two strings word1 and word2, return the minimum number of steps required to make word1 and word2 the same.
In one step, you can delete exactly one character in either string.

Example 1:
Input: word1 = "sea", word2 = "eat"
Output: 2
Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".

Example 2:
Input: word1 = "leetcode", word2 = "etco"
Output: 4

Constraints:
1 <= word1.length, word2.length <= 500
word1 and word2 consist of only lowercase English letters.
*/

namespace LeetCode.DeleteOperationForTwoStrings;

/*
DP, similar to LeetCode.LongestCommonSubsequence
*/
public class Solution
{
  public int MinDistance(string word1, string word2)
  {
    // dp[i,j] represents the longest common sequence between word1[0..i-1] and word2[0..j-1]
    var dp = new int[word1.Length + 1, word2.Length + 1];
    for (int i = 0; i <= word1.Length; i++)
    {
      for (int j = 0; j <= word2.Length; j++)
      {
        if (i == 0 || j == 0) continue;
        if (word1[i - 1] == word2[j - 1]) dp[i, j] = 1 + dp[i - 1, j - 1];
        else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
      }
    }
    return word1.Length + word2.Length - 2 * dp[word1.Length, word2.Length];
  }
}
