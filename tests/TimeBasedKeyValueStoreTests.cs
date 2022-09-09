using LeetCode.TimeBasedKeyValueStore;

namespace tests;

public class TimeBasedKeyValueStoreTests
{
  [Fact]
  public void Test1()
  {
    TimeMap timeMap = new TimeMap();
    timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
    Assert.Equal("bar", timeMap.Get("foo", 1)); // return "bar"
    // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
    Assert.Equal("bar", timeMap.Get("foo", 3));
    timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
    Assert.Equal("bar2", timeMap.Get("foo", 4)); // return "bar2"
    Assert.Equal("bar2", timeMap.Get("foo", 5)); // return "bar2"
  }
}
