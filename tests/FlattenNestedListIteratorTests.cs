using LeetCode.FlattenNestedListIterator;

namespace tests;

/*
mock up a NestedInteger implementation for testing only
*/
class NestedIntegerC : NestedInteger
{
  private Object value;

  public NestedIntegerC(int integer)
  {
    value = integer;
  }

  public NestedIntegerC(IList<NestedInteger> integers)
  {
    value = integers;
  }

  public int GetInteger()
  {
    return (int)value;
  }

  public IList<NestedInteger> GetList()
  {
    return (IList<NestedInteger>)value;
  }

  public bool IsInteger()
  {
    return value is int;
  }
}

public class FlattenNestedListIteratorTests
{
  public static IEnumerable<object[]> GetTestData()
  {
    yield return new object[]{
      new List<NestedInteger>{
        new NestedIntegerC(1),
        new NestedIntegerC(new List<NestedInteger>{
          new NestedIntegerC(4),
          new NestedIntegerC(6),
        }),
      },
      new int[]{1,4,6},
    };

    yield return new object[]{
      new List<NestedInteger>{
        new NestedIntegerC(new List<NestedInteger>{
          new NestedIntegerC(1),
          new NestedIntegerC(1),
        }),
        new NestedIntegerC(2),
        new NestedIntegerC(new List<NestedInteger>{
          new NestedIntegerC(1),
          new NestedIntegerC(1),
        })
      },
      new int[]{1,1,2,1,1},
    };
  }

  [Theory]
  [MemberData(nameof(GetTestData))]
  public void Test1(IList<NestedInteger> ls, int[] expect)
  {
    var it = new NestedIterator(ls);
    foreach (var e in expect)
    {
      Assert.True(it.HasNext());
      Assert.Equal(e, it.Next());
    }
  }
}