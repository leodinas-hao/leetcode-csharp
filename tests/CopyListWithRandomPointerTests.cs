using LeetCode.CopyListWithRandomPointer;

namespace tests;

public class CopyListWithRandomPointerTests
{
  private Node CreateRandomPointer(int?[][] nodes)
  {
    if (nodes == null || nodes.Length == 0) return null;
    var head = new Node(0);
    var node = head;
    var map = new Dictionary<int, Node>();

    // assign node with linked next node (no touch random node)
    for (int i = 0; i < nodes.Length; i++)
    {
      var temp = new Node((int)nodes[i][0]);
      map.Add(i, temp);
      node.next = temp;
      node = node.next;
    }

    // assign random nodes
    for (int i = 0; i < nodes.Length; i++)
    {
      if (nodes[i][1] != null)
      {
        map[i].random = map[(int)nodes[i][1]];
      }
    }

    return head.next;
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[][]{
        new int?[]{7, null},
        new int?[]{13, 0},
        new int?[]{11, 4},
        new int?[]{10, 2},
        new int?[]{1, 0}
      },
    };

    yield return new object[]{
      new int?[][]{
        new int?[]{1, 1},
        new int?[]{2, 1}
      },
    };

    yield return new object[]{
      new int?[][]{
        new int?[]{3, null},
        new int?[]{3, 0},
        new int?[]{3, null}
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[][] nodes)
  {
    var head = CreateRandomPointer(nodes);
    var copy = new Solution().CopyRandomList(head);
    Assert.NotSame(copy, head);
    while (head != null)
    {
      Assert.Equal(head.val, copy.val);
      if (head.random != null)
      {
        Assert.Equal(head.random.val, copy.random.val);
      }
      head = head.next;
      copy = copy.next;
    }
  }
}
