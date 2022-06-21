using LeetCode.MergeTwoBinaryTrees;

namespace tests;

public class MergeTwoBinaryTreesTests
{
  private IList<int?> ToList(TreeNode node)
  {
    var ls = new List<int?>();

    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(node);

    while (queue.Any())
    {
      var n = queue.Dequeue();
      ls.Add(n == null ? null : n.val);
      if (n != null && (n.right != null || n.left != null))
      {
        queue.Enqueue(n.left);
        queue.Enqueue(n.right);
      }
    }

    return ls;
  }
  private TreeNode ToTreeNode(IList<int?> t)
  {
    // convert a list to a binary tree
    if (t == null || t.Count == 0 || t[0] == null) return null;

    TreeNode root = new TreeNode((int)t[0]);
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int i = 1;
    while (queue.Any() && i < t.Count)
    {
      var node = queue.Dequeue();
      if (t[i] != null)
      {
        var left = new TreeNode((int)t[i]);
        node.left = left;
        queue.Enqueue(left);
      }
      if (i + 1 < t.Count && t[i + 1] != null)
      {
        var right = new TreeNode((int)t[i + 1]);
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
      new List<int?>{1,3,2,5},
      new List<int?>{2,1,3,null,4,null,7},
      new List<int?>{3,4,5,5,4,null,7},
    };
    yield return new object[]{
      new List<int?>{1},
      new List<int?>{1,2},
      new List<int?>{2,2},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(IList<int?> l1, IList<int?> l2, IList<int?> expect)
  {
    var t1 = ToTreeNode(l1);
    var t2 = ToTreeNode(l2);
    var tree = new Solution().MergeTrees(t1, t2);
    var ls = ToList(tree);
    for (int i = 0; i < expect.Count; i++)
    {
      Assert.Equal(expect[i], ls[i]);
    }
  }
}
