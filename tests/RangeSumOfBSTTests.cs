using LeetCode.RangeSumOfBST;

namespace tests;

public class RangeSumOfBSTTests
{
  // convert int array to binary tree
  private TreeNode ToTreeNode(int?[] nodes)
  {
    if (nodes == null || nodes.Length == 0 || nodes[0] == null) return null;

    TreeNode root = new TreeNode((int)nodes[0]);

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int i = 1;  // tracking index of the nodes array
    while (queue.Any() && i < nodes.Length)
    {
      var node = queue.Dequeue();

      // add left node
      if (nodes[i] != null)
      {
        var left = new TreeNode((int)nodes[i]);
        node.left = left;
        queue.Enqueue(left);
      }
      // add right node
      if (i + 1 < nodes.Length && nodes[i + 1] != null)
      {
        var right = new TreeNode((int)nodes[i + 1]);
        node.right = right;
        queue.Enqueue(right);
      }
      i += 2;
    }
    return root;
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[]{10,5,15,3,7,null,18},
      7,
      15,
      32
    };

    yield return new object[]{
      new int?[]{10,5,15,3,7,13,18,1,null,6},
      6,
      10,
      23
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nodes, int low, int high, int expect)
  {
    var root = ToTreeNode(nodes);
    Assert.Equal(expect, new Solution().RangeSumBST(root, low, high));
  }
}