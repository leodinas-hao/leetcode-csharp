using LeetCode.BinarySearchTreeIterator;

namespace tests;

public class BinarySearchTreeIteratorTests
{
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

  [Fact]
  public void Test1()
  {
    var root = ToTreeNode(new int?[] { 7, 3, 15, null, null, 9, 20 });
    var iterator = new BSTIterator(root);

    Assert.Equal(3, iterator.Next());    // return 3
    Assert.Equal(7, iterator.Next());    // return 7
    Assert.Equal(true, iterator.HasNext()); // return True
    Assert.Equal(9, iterator.Next());    // return 9
    Assert.Equal(true, iterator.HasNext()); // return True
    Assert.Equal(15, iterator.Next());    // return 15
    Assert.Equal(true, iterator.HasNext()); // return True
    Assert.Equal(20, iterator.Next());    // return 20
    Assert.Equal(false, iterator.HasNext()); // return False
  }
}