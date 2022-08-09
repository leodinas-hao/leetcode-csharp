using LeetCode.SubtreeOfAnotherTree;

namespace tests;

public class SubtreeOfAnotherTreeTests
{
  private TreeNode ToTreeNode(int?[] nums)
  {
    // no Node can be produced when first node is null or empty value list
    if (nums == null || nums.Length == 0 || nums[0] == null) return null;

    TreeNode root = new TreeNode();
    root.val = (int)nums[0];
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int i = 0;
    while (queue.Any() && i < nums.Length)
    {
      var node = queue.Dequeue();
      // left node
      i++;
      if (i < nums.Length && nums[i] != null)
      {
        node.left = new TreeNode((int)nums[i]);
        queue.Enqueue(node.left);
      }
      // right node
      i++;
      if (i < nums.Length && nums[i] != null)
      {
        node.right = new TreeNode((int)nums[i]);
        queue.Enqueue(node.right);
      }
    }
    return root;
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[]{3,4,5,1,2},
      new int?[]{4,1,2},
      true
    };
    yield return new object[]{
      new int?[]{3,4,5,1,2,null,null,null,null,0},
      new int?[]{4,1,2},
      false
    };
    yield return new object[]{
      new int?[]{1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,2},
      new int?[]{1,null,1,null,1,null,1,null,1,null,1,2},
      true
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] t1, int?[] t2, bool expect)
  {
    var r1 = ToTreeNode(t1);
    var r2 = ToTreeNode(t2);
    Assert.Equal(expect, new Solution().IsSubtree(r1, r2));
  }
}
