using LeetCode.KthSmallestElementInABST;

namespace tests;

public class KthSmallestElementInABSTTests
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
      new int?[]{3,1,4,null,2},
      1,
      1
    };
    yield return new object[]{
      new int?[]{5,3,6,2,4,null,null,1},
      3,
      3
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nums, int k, int expect)
  {
    var root = ToTreeNode(nums);
    Assert.Equal(expect, new Solution().KthSmallest(root, k));
  }
}
