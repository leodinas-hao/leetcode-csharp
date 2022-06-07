using LeetCode.AddTwoNumbersII;

namespace tests;

public class AddTwoNumbersIITests
{
  private ListNode ToListNode(int[] ls)
  {
    var head = new ListNode(ls[0]);
    var node = head;
    for (int i = 1; i < ls.Length; i++)
    {
      node.next = new ListNode(ls[i]);
      node = node.next;
    }
    return head;
  }

  private int[] ToArray(ListNode node)
  {
    if (node == null) return new int[0];
    var ls = new List<int>();
    ls.Add(node.val);
    while (node.next != null)
    {
      node = node.next;
      ls.Add(node.val);
    }
    return ls.ToArray();
  }

  [Theory]
  [InlineData(new int[] { 7, 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 8, 0, 7 })]
  [InlineData(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 8, 0, 7 })]
  [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
  [InlineData(new int[] { 3, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 7 }, new int[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, 6 })]
  public void Test1(int[] l1, int[] l2, int[] expect)
  {
    var node = new Solution().AddTwoNumbers(ToListNode(l1), ToListNode(l2));
    var arr = ToArray(node);
    Assert.Equal(expect.Length, arr.Length);
    for (int i = 0; i < arr.Length; i++)
    {
      Assert.Equal(expect[i], arr[i]);
    }
  }

  [Fact]
  public void Test2()
  {
    int[] arr1 = { 3, 1, 2 };
    int[] arr2 = new int[arr1.Length];
    arr1.CopyTo(arr2, 0);
    // Array.Copy(arr1, arr2, arr1.Length);
    Array.Sort(arr1);
    Assert.Equal(arr1[0], 1);
    Assert.Equal(arr2[0], 3);

    int[] arr3 = (int[])arr2.Clone();
    Assert.Equal(arr3[1], arr2[1]);

    int[,] arr4 = {
      {100,200,50},
      {2,1,5},
    };
    // clone can shadow copy a jagged array
    int[,] arr5 = (int[,])arr4.Clone();
    arr4[0, 0] = 0;
    Assert.Equal(arr4.Length, arr5.Length);
    Assert.NotEqual(arr4[0, 0], arr5[0, 0]);

    // clone only copy the reference of the inner array
    int[][] arr6 = {
      new int[]{100,200,50},
      new int[]{2,1,5},
    };
    int[][] arr7 = (int[][])arr6.Clone();
    Array.Sort(arr6[0]);
    Assert.Equal(arr7.Length, arr6.Length);
    Assert.Equal(arr7[0].Length, arr6[0].Length);
    Assert.Equal(arr7[0][0], arr6[0][0]);

    // copy inner array manually to get a deep shadow copy of 2d array
    int[][] arr8 = {
      new int[]{100,200,50},
      new int[]{2,1,5},
    };
    int[][] arr9 = new int[arr8.Length][];
    for (int i = 0; i < arr8.Length; i++)
    {
      arr9[i] = new int[arr8[i].Length];
      arr8[i].CopyTo(arr9[i], 0);
    }
    Array.Sort(arr8[0]);
    Assert.Equal(arr8.Length, arr9.Length);
    Assert.Equal(arr8[0].Length, arr9[0].Length);
    Assert.NotEqual(arr8[0][0], arr9[0][0]);
  }
}
