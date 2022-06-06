using LeetCode.MinimumDepthOfBinaryTree;

namespace tests;

public class MinimumDepthOfBinaryTreeTests
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
      node1, 2
    };

    var node2 = new TreeNode(2);
    node2.right = new TreeNode(3);
    node2.right.right = new TreeNode(4);
    node2.right.right.right = new TreeNode(5);
    node2.right.right.right.right = new TreeNode(6);
    yield return new object[] {
      node2, 5
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(TreeNode node, int expect)
  {
    int min = new Solution().MinDepth(node);
    Assert.Equal(expect, min);
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test2(TreeNode node, int expect)
  {
    int min = new Solution2().MinDepth(node);
    Assert.Equal(expect, min);
  }
}
