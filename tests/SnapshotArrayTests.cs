using LeetCode.SnapshotArray;

namespace tests;

public class SnapshotArrayTests
{
  [Fact]
  public void Test1()
  {
    var snap = new SnapshotArray(3); // set the length to be 3
    snap.Set(0, 5);  // Set array[0] = 5
    Assert.Equal(0, snap.Snap());  // Take a snapshot, return snap_id = 0
    snap.Set(0, 6);
    Assert.Equal(5, snap.Get(0, 0));  // Get the value of array[0] with snap_id = 0, return 5
  }
}