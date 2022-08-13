/*
Word Search
https://leetcode.com/problems/word-search/

Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, 
where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

Example 1:
[(A),(B),(C),"E"]
["S","F",(C),"S"]
["A",(D),(E),"E"]
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true

Example 2:
["A","B","C","E"]
["S","F","C",(S)]
["A","D",(E),(E)]
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true

Example 3:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false

Constraints:
m == board.length
n = board[i].length
1 <= m, n <= 6
1 <= word.length <= 15
board and word consists of only lowercase and uppercase English letters.
*/

namespace LeetCode.WordSearch;


/*
DFS
*/
public class Solution
{
  private bool Search(char[][] board, string word, int r, int c, int i)
  {
    // reached the end of the word
    if (i == word.Length) return true;

    // out of the board
    if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length) return false;
    if (board[r][c] != word[i]) return false;

    // mark the cell to * to avoid revisit
    board[r][c] = '*';

    // check 4 directions
    bool found = Search(board, word, r + 1, c, i + 1)
      || Search(board, word, r - 1, c, i + 1)
      || Search(board, word, r, c + 1, i + 1)
      || Search(board, word, r, c - 1, i + 1);

    board[r][c] = word[i];

    return found;
  }

  public bool Exist(char[][] board, string word)
  {
    if (board.Length * board[0].Length < word.Length) return false;

    for (int i = 0; i < board.Length; i++)
    {
      for (int j = 0; j < board[0].Length; j++)
      {
        if (Search(board, word, i, j, 0)) return true;
      }
    }

    return false;
  }
}