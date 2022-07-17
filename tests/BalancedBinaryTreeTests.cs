using LeetCode.BalancedBinaryTree;

namespace tests;

public class BalancedBinaryTreeTests
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
      new int?[]{3,9,20,null,null,15,7},
      true,
    };
    yield return new object[]{
      new int?[]{1,2,2,3,3,null,null,4,4},
      false,
    };
    yield return new object[]{
      new int?[]{},
      true,
    };
    yield return new object[]{
      new int?[]{1,null,2,null,3},
      false,
    };
    yield return new object[]{
      new int?[]{1,2,2,3,null,null,3,4,null,null,4},
      false,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nodes, bool expect)
  {
    var root = ToTreeNode(nodes);
    Assert.Equal(expect, new Solution().IsBalanced(root));
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(int?[] nodes, bool expect)
  {
    var root = ToTreeNode(nodes);
    Assert.Equal(expect, new Solution2().IsBalanced(root));
  }
}