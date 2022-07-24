using LeetCode.NaryTreeLevelOrderTraversal;

namespace tests;

public class NaryTreeLevelOrderTraversalTests
{
  private Node ToNode(int?[] nums)
  {
    if (nums == null || nums.Length == 0 || nums[0] == null) return null;
    var root = new Node((int)nums[0], new List<Node>());  // first node can't be null
    var queue = new Queue<Node>();
    Node node = root;
    for (int i = 2; i < nums.Length; i++)
    {
      if (nums[i] == null)
      {
        node = queue.Dequeue();
      }
      else
      {
        // create new node
        var cNode = new Node((int)nums[i], new List<Node>());
        // add the node to current node's children
        node.children.Add(cNode);
        // add the node to queue
        queue.Enqueue(cNode);
      }
    }
    return root;
  }

  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new int?[]{1,null,3,2,4,null,5,6},
      new int[][]{
        new int[]{1},
        new int[]{3,2,4},
        new int[]{5,6},
      },
    };

    yield return new object[]{
      new int?[]{1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14},
      new int[][]{
        new int[]{1},
        new int[]{2,3,4,5},
        new int[]{6,7,8,9,10},
        new int[]{11,12,13},
        new int[]{14},
      },
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(int?[] nums, int[][] expect)
  {
    var root = ToNode(nums);
    var result = new Solution().LevelOrder(root);
    Assert.Equal(result.Count, expect.Length);
    for (int i = 0; i < result.Count; i++)
    {
      Assert.Equal(expect[i], result[i]);
    }
  }
}
