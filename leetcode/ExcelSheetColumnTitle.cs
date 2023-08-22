/*
Excel Sheet Column Title
https://leetcode.com/problems/excel-sheet-column-title/

Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28 
...

Example 1:
Input: columnNumber = 1
Output: "A"

Example 2:
Input: columnNumber = 28
Output: "AB"

Example 3:
Input: columnNumber = 701
Output: "ZY"

Constraints:
1 <= columnNumber <= 2^31 - 1
*/

namespace LeetCode.ExcelSheetColumnTitle;

public class Solution
{
  public string ConvertToTitle(int columnNumber)
  {
    string output = "";
    while (columnNumber > 0)
    {
      char ch = (char)('A' + (columnNumber - 1) % 26);
      output = ch + output;
      columnNumber = (columnNumber - 1) / 26;
    }
    return output;
  }
}