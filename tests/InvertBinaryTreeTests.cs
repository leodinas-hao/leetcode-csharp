using LeetCode.InvertBinaryTree;

namespace tests;

public class InvertBinaryTreeTests
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
      new int?[]{4,2,7,1,3,6,9},
      new int?[]{4,7,2,9,6,3,1}
    };
    yield return new object[]{
      new int?[]{2,1,3},
      new int?[]{2,3,1},
    };
    yield return new object[]{
      new int?[]{},
      new int?[]{},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nums, int?[] expect)
  {
    var root = ToTreeNode(nums);
    var inverted = new Solution().InvertTree(root);
    if (root == null) Assert.Null(inverted);
    else
    {
      var queue = new Queue<TreeNode>();
      var ls = new List<int?>();
      queue.Enqueue(inverted);
      ls.Add(inverted.val);
      while (queue.Any())
      {
        var n = queue.Dequeue();
        if (n.left != null || n.right != null)
        {
          queue.Enqueue(n.left);
          ls.Add(n.left?.val);
          queue.Enqueue(n.right);
          ls.Add(n.right?.val);
        }
      }
      Assert.Equal(expect.Length, ls.Count);
      Assert.Equal(expect, ls);
    }
  }
}