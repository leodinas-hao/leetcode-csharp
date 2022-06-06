using LeetCode.MaximumDepthOfBinaryTree;

namespace tests;

public class MaximumDepthOfBinaryTree
{
  public static IEnumerable<object[]> GetTestData()
  {
    var node1 = new TreeNode(3);
    node1.right = new TreeNode(9);
    var node1Left = new TreeNode(20);
    node1Left.left = new TreeNode(15);
    node1Left.right = new TreeNode(7);
    node1.left = node1Left;
    yield return new object[]{
      node1, 3
    };

    var node2 = new TreeNode(1);
    node2.right = new TreeNode(2);
    yield return new object[] {
      node2, 2
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(TreeNode node, int expect)
  {
    int max = new Solution().MaxDepth(node);
    Assert.Equal(expect, max);
  }
}