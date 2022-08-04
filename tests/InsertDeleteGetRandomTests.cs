using LeetCode.InsertDeleteGetRandom;

namespace tests;

public class InsertDeleteGetRandomTests
{
  [Fact]
  public void Test1()
  {
    RandomizedSet rdm = new RandomizedSet();
    Assert.True(rdm.Insert(1)); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
    Assert.False(rdm.Remove(2)); // Returns false as 2 does not exist in the set.
    Assert.True(rdm.Insert(2)); // Inserts 2 to the set, returns true. Set now contains [1,2].
    Assert.True(new int[] { 1, 2 }.Contains(rdm.GetRandom())); // getRandom() should return either 1 or 2 randomly.
    Assert.True(rdm.Remove(1)); // Removes 1 from the set, returns true. Set now contains [2].
    Assert.False(rdm.Insert(2)); // 2 was already in the set, so return false.
    Assert.Equal(2, rdm.GetRandom()); // Since 2 is the only number in the set, getRandom() will always return 2.
  }
}