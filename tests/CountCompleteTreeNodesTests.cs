using LeetCode.CountCompleteTreeNodes;

namespace tests;

public class CountCompleteTreeNodesTests
{
  private TreeNode ToTreeNode(int[] nodes)
  {
    if (nodes == null || nodes.Length == 0) return null;

    TreeNode root = new TreeNode(nodes[0]);

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int i = 1;  // tracking index of the nodes array
    while (queue.Any() && i < nodes.Length)
    {
      var node = queue.Dequeue();

      // add left node
      var left = new TreeNode(nodes[i]);
      node.left = left;
      queue.Enqueue(left);

      // add right node
      if (i + 1 < nodes.Length)
      {
        var right = new TreeNode(nodes[i + 1]);
        node.right = right;
        queue.Enqueue(right);
      }
      i += 2;
    }
    return root;
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
  [InlineData(new int[] { }, 0)]
  [InlineData(new int[] { 1 }, 1)]
  public void Test1(int[] nodes, int expect)
  {
    var root = ToTreeNode(nodes);
    Assert.Equal(expect, new Solution().CountNodes(root));
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
  [InlineData(new int[] { }, 0)]
  [InlineData(new int[] { 1 }, 1)]
  public void Test2(int[] nodes, int expect)
  {
    var root = ToTreeNode(nodes);
    Assert.Equal(expect, new Solution2().CountNodes(root));
  }
}
