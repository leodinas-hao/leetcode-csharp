using LeetCode.BinaryTreeLevelOrderTraversal;

namespace tests;

public class BinaryTreeLevelOrderTraversalTests
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
      new int?[]{3,9,20,null,null,15,7},
      3,
    };
    yield return new object[]{
      new int?[]{1},
      1
    };
    yield return new object[]{
      new int?[]{},
      0
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nums, int levels)
  {
    var root = ToTreeNode(nums);
    var result = new Solution().LevelOrder(root);
    Assert.Equal(levels, result.Count);
    Assert.Equal(nums.Count(n => n != null), result.Sum(r => r.Count));
  }
}