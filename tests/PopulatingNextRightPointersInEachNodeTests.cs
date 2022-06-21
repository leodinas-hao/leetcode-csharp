using LeetCode.PopulatingNextRightPointersInEachNode;

namespace tests;

public class PopulatingNextRightPointersInEachNodeTests
{
  private Node ToNode(IList<int> ls)
  {
    if (ls == null || ls.Count == 0) return null;
    Node root = new Node();
    root.val = ls[0];
    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(root);
    int i = 1;
    while (queue.Any() && i < ls.Count)
    {
      var node = queue.Dequeue();
      // left node
      var left = new Node(ls[i]);
      node.left = left;
      queue.Enqueue(left);
      // right node
      if (i + 1 < ls.Count)
      {
        var right = new Node(ls[i + 1]);
        node.right = right;
        queue.Enqueue(right);
      }
      i += 2;
    }
    return root;
  }

  [Theory]
  [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
  [InlineData(new int[] { })]
  public void Test1(IList<int> ls)
  {
    var node = ToNode(ls);
    var result = new Solution().Connect(node);
    if (ls.Count > 0)
    {
      Assert.NotNull(result);
      Assert.Equal(result.left.next, result.right);
    }
  }
}
