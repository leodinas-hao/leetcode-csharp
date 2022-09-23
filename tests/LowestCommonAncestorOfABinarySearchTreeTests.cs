using LeetCode.LowestCommonAncestorOfABinarySearchTree;

namespace tests;

public class LowestCommonAncestorOfABinarySearchTreeTests
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

  // given constraint that all node is unique
  // search the node with the given value
  private TreeNode SearchNode(TreeNode root, int val)
  {
    var queue = new Queue<TreeNode>();
    if (root != null) queue.Enqueue(root);
    while (queue.Any())
    {
      var n = queue.Count;
      for (int i = 0; i < n; i++)
      {
        var node = queue.Dequeue();
        if (node.val == val) return node;
        else
        {
          if (node.left != null) queue.Enqueue(node.left);
          if (node.right != null) queue.Enqueue(node.right);
        }
      }
    }
    // this should not happen with given constraint
    throw new InvalidDataException();
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[]{2,1},
      2,
      1,
      2
    };
    yield return new object[]{
      new int?[]{6,2,8,0,4,7,9,null,null,3,5},
      2,
      4,
      2
    };
    yield return new object[]{
      new int?[]{6,2,8,0,4,7,9,null,null,3,5},
      2,
      8,
      6
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nodes, int p, int q, int expect)
  {
    var root = ToTreeNode(nodes);
    var pNode = SearchNode(root, p);
    var qNode = SearchNode(root, q);
    Assert.Equal(expect, new Solution().LowestCommonAncestor(root, pNode, qNode).val);
  }
}