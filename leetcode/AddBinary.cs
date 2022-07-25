/*
Add binary
https://leetcode.com/problems/add-binary/

Given two binary strings a and b, return their sum as a binary string.

Example 1:
Input: a = "11", b = "1"
Output: "100"

Example 2:
Input: a = "1010", b = "1011"
Output: "10101"

Constraints:
1 <= a.length, b.length <= 10^4
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/

namespace LeetCode.AddBinary;

using System.Text;

public class Solution
{
  public string AddBinary(string a, string b)
  {
    int ai = a.Length - 1, bi = b.Length - 1;
    int carry = 0;
    StringBuilder sb = new StringBuilder();
    while (ai >= 0 || bi >= 0 || carry > 0)
    {
      // "char - '0'" to get the actual integer value of the char
      int numa = ai >= 0 ? a[ai] - '0' : 0;
      int numb = bi >= 0 ? b[bi] - '0' : 0;
      int temp = numa + numb + carry;
      if (temp == 3)
      {
        // '1' + '1' + '1'
        sb.Insert(0, 1);
        carry = 1;
      }
      else if (temp == 2)
      {
        // '0' + '1' + '1'
        sb.Insert(0, 0);
        carry = 1;
      }
      else
      {
        // '0' + '0' + '1'
        // '0' + '0' + '0'
        sb.Insert(0, temp);
        carry = 0;
      }

      bi--;
      ai--;
    }
    return sb.ToString();
  }
}
