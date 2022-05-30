/*
Largest Time for Given Digits
https://leetcode.com/problems/largest-time-for-given-digits/

Given an array arr of 4 digits, find the latest 24-hour time that can be made using each digit exactly once.

24-hour times are formatted as "HH:MM", where HH is between 00 and 23, and MM is between 00 and 59. 
The earliest 24-hour time is 00:00, and the latest is 23:59.

Return the latest 24-hour time in "HH:MM" format. If no valid time can be made, return an empty string.

Example 1:
Input: arr = [1,2,3,4]
Output: "23:41"
Explanation: The valid 24-hour times are "12:34", "12:43", "13:24", "13:42", "14:23", "14:32", "21:34", "21:43", "23:14", and "23:41". 
Of these times, "23:41" is the latest.

Example 2:
Input: arr = [5,5,5,5]
Output: ""
Explanation: There are no valid 24-hour times as "55:55" is not valid.

Constraints:

arr.length == 4
0 <= arr[i] <= 9
*/

namespace LeetCode.LargestTimeForGivenDigits;

public class Solution
{
  // store max time in decimal: 10:09 => 10 * 60 + 9 = 609
  private int maxTime = -1;

  public string LargestTimeFromDigits(int[] arr)
  {
    if (!arr.Any(i => i <= 2) || arr.All(i => i >= 6))
    {
      // find easy way out by checking arrays, which:
      // 1) don't have 0, 1 or 2
      // 2) all above 6
      return "";
    }

    // make all possible permutations out of the array
    // permutation is an array of positions of each number in the array e.g. [0,1,2,3]
    // it can be done via multiple loops
    for (int i1 = 0; i1 < arr.Length; i1++)
    {
      for (int i2 = 0; i2 < arr.Length; i2++)
      {
        for (int i3 = 0; i3 < arr.Length; i3++)
        {
          // cannot have 2 position with same number/index
          if (i1 == i2 || i2 == i3 || i1 == i3)
          {
            continue;
          }
          // the last position is fixed once all other 3 chosen
          int i4 = 6 - i1 - i2 - i3;
          // filter & sort to find the largest time out of permutations
          ValidatePermutation(new int[] { arr[i1], arr[i2], arr[i3], arr[i4] });
        }
      }
    }

    if (maxTime == -1)
    {
      return "";
    }
    else
    {
      return $"{(maxTime / 60):D2}:{(maxTime % 60):D2}";
    }

  }

  private void ValidatePermutation(int[] arr)
  {
    int hour = arr[0] * 10 + arr[1];
    int minute = arr[2] * 10 + arr[3];
    if (hour <= 23 && minute <= 59)
    {
      maxTime = Math.Max(maxTime, hour * 60 + minute);
    }
  }
}


public class Solution2
{
  private int maxTime = -1;

  private void ValidatePermutation(int[] arr)
  {
    int hour = arr[0] * 10 + arr[1];
    int minute = arr[2] * 10 + arr[3];
    if (hour <= 23 && minute <= 59)
    {
      maxTime = Math.Max(maxTime, hour * 60 + minute);
    }
  }

  private void Swap(int[] arr, int i, int j)
  {
    if (i != j)
    {
      int temp = arr[i];
      arr[i] = arr[j];
      arr[j] = temp;
    }
  }

  private void Permutate(int[] arr, int index)
  {
    // recursively backtracking to find all permutations

    // reached the end
    if (index == arr.Length)
    {
      // check if it's valid HH:MM, if so compare to see if it's the max
      ValidatePermutation(arr);
      return;
    }

    for (int i = index; i < arr.Length; i++)
    {
      Swap(arr, i, index);
      Permutate(arr, index + 1);
      Swap(arr, i, index);
    }
  }

  public string LargestTimeFromDigits(int[] arr)
  {
    Permutate(arr, 0);
    if (maxTime == -1)
    {
      return "";
    }
    else
    {
      return $"{(maxTime / 60):D2}:{(maxTime % 60):D2}";
    }
  }

}
