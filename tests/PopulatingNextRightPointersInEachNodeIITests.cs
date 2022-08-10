using LeetCode.PopulatingNextRightPointersInEachNodeII;

namespace tests;

public class PopulatingNextRightPointersInEachNodeIITests
{
  private Node ToNode(int?[] nums)
  {
    // no Node can be produced when first node is null or empty value list
    if (nums == null || nums.Length == 0 || nums[0] == null) return null;

    Node root = new Node();
    root.val = (int)nums[0];
    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(root);
    int i = 0;
    while (queue.Any() && i < nums.Length)
    {
      var node = queue.Dequeue();
      // left node
      i++;
      if (i < nums.Length && nums[i] != null)
      {
        node.left = new Node((int)nums[i]);
        queue.Enqueue(node.left);
      }
      // right node
      i++;
      if (i < nums.Length && nums[i] != null)
      {
        node.right = new Node((int)nums[i]);
        queue.Enqueue(node.right);
      }
    }
    return root;
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[]{1,2,3,4,5,null,7},
      new int?[]{null,3,null,5,7,null}
    };
    yield return new object[]{
      new int?[]{},
      new int?[]{}
    };
    yield return new object[]{
      new int?[]{0,2,4,1,null,3,-1,5,1,null,6,null,8},
      new int?[]{null,4,null,3,-1,null,1,6,8,null}
    };
    yield return new object[]{
      new int?[]{1,2,3,4,5,null,6,7,null,null,null,null,8},
      new int?[]{null,3,null,5,6,null,8,null}
    };
    yield return new object[]{
      new int?[]{1,2,3,4,5},
      new int?[]{null,3,null,5,null}
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nums, int?[] expect)
  {
    var root = ToNode(nums);
    var result = new Solution().Connect(root);
    var queue = new Queue<Node>();
    if (result != null)
    {
      queue.Enqueue(result);
      int i = 0;
      while (queue.Any() || i < expect.Length)
      {
        var node = queue.Dequeue();
        if (expect[i] == null) Assert.True(node.next == null);
        else Assert.True(node.next.val == expect[i]);
        if (node.left != null) queue.Enqueue(node.left);
        if (node.right != null) queue.Enqueue(node.right);
        i++;
      }
      Assert.Equal(expect.Length, i);
    }
  }
}
