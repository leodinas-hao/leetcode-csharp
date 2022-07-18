using LeetCode.LinkedListInBinaryTree;

namespace tests;

public class LinkedListInBinaryTreeTests
{
  private ListNode ToListNode(int[] nums)
  {
    var dummy = new ListNode();
    var node = dummy;
    foreach (var num in nums)
    {
      node.next = new ListNode(num);
      node = node.next;
    }
    return dummy.next;
  }

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
      new int[]{4,2,8},
      new int?[]{1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3},
      true,
    };
    yield return new object[]{
      new int[]{1,4,2,6},
      new int?[]{1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3},
      true,
    };
    yield return new object[]{
      new int[]{1,4,2,6,8},
      new int?[]{1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3},
      false,
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int[] list, int?[] tree, bool expect)
  {
    var head = ToListNode(list);
    var root = ToTreeNode(tree);
    Assert.Equal(expect, new Solution().IsSubPath(head, root));
  }
}