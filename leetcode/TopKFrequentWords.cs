/*
Top K Frequent Words
https://leetcode.com/problems/top-k-frequent-words/

Given an array of strings words and an integer k, return the k most frequent strings.
Return the answer sorted by the frequency from highest to lowest. 
Sort the words with the same frequency by their lexicographical order.

Example 1:
Input: words = ["i","love","leetcode","i","love","coding"], k = 2
Output: ["i","love"]
Explanation: "i" and "love" are the two most frequent words.
Note that "i" comes before "love" due to a lower alphabetical order.

Example 2:
Input: words = ["the","day","is","sunny","the","the","the","sunny","is","is"], k = 4
Output: ["the","is","sunny","day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.

Constraints:
1 <= words.length <= 500
1 <= words[i].length <= 10
words[i] consists of lowercase English letters.
k is in the range [1, The number of unique words[i]]

Follow-up: Could you solve it in O(n log(k)) time and O(n) extra space?
*/

namespace LeetCode.TopKFrequentWords;

class WordsFrequentComparer : IComparer<KeyValuePair<string, int>>
{
  public WordsFrequentComparer() { }

  int IComparer<KeyValuePair<string, int>>.Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
  {
    if (x.Value > y.Value) return -1;
    else if (x.Value < y.Value) return 1;
    else return x.Key.CompareTo(y.Key);
  }
}

public class Solution
{
  public IList<string> TopKFrequent(string[] words, int k)
  {
    var dict = new Dictionary<string, int>();
    foreach (var w in words)
    {
      dict[w] = 1 + (dict.ContainsKey(w) ? dict[w] : 0);
    }

    return dict.OrderBy(p => p, new WordsFrequentComparer()).Take(k).Select(p => p.Key).ToList();
  }
}
