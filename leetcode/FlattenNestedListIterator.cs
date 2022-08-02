/*
Flatten Nested List Iterator
https://leetcode.com/problems/flatten-nested-list-iterator/

You are given a nested list of integers nestedList. Each element is either an integer or a list 
whose elements may also be integers or other lists. Implement an iterator to flatten it.

Implement the NestedIterator class:

NestedIterator(List<NestedInteger> nestedList) Initializes the iterator with the nested list nestedList.
int next() Returns the next integer in the nested list.
boolean hasNext() Returns true if there are still some integers in the nested list and false otherwise.
Your code will be tested with the following pseudocode:

initialize iterator with nestedList
res = []
while iterator.hasNext()
    append iterator.next() to the end of res
return res
If res matches the expected flattened list, then your code will be judged as correct.

Example 1:
Input: nestedList = [[1,1],2,[1,1]]
Output: [1,1,2,1,1]
Explanation: By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,1,2,1,1].

Example 2:
Input: nestedList = [1,[4,[6]]]
Output: [1,4,6]
Explanation: By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,4,6].

Constraints:
1 <= nestedList.length <= 500
The values of the integers in the nested list is in the range [-10^6, 10^6].
*/

namespace LeetCode.FlattenNestedListIterator;


// This is the interface that allows for creating nested lists.
// You should not implement it, or speculate about its implementation
public interface NestedInteger
{

  // @return true if this NestedInteger holds a single integer, rather than a nested list.
  bool IsInteger();

  // @return the single integer that this NestedInteger holds, if it holds a single integer
  // Return null if this NestedInteger holds a nested list
  int GetInteger();

  // @return the nested list that this NestedInteger holds, if it holds a nested list
  // Return null if this NestedInteger holds a single integer
  IList<NestedInteger> GetList();
}


/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */

public class NestedIterator
{
  private IList<int> list = new List<int>();
  private int index = 0;

  private void Flatten(NestedInteger nestedInteger)
  {
    if (nestedInteger.IsInteger())
    {
      list.Add(nestedInteger.GetInteger());
    }
    else
    {
      IList<NestedInteger> nestedList = nestedInteger.GetList();
      foreach (NestedInteger ni in nestedList)
      {
        Flatten(ni);
      }
    }
  }

  public NestedIterator(IList<NestedInteger> nestedList)
  {
    foreach (NestedInteger ni in nestedList)
    {
      Flatten(ni);
    }
  }

  public bool HasNext()
  {
    return index < list.Count;
  }

  public int Next()
  {
    return list[index++];
  }
}
