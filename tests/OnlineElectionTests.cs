using LeetCode.OnlineElection;

namespace tests;

public class OnlineElectionTests
{
  [Fact]
  public void Test1()
  {
    var tvc = new TopVotedCandidate(new int[] { 0, 1, 1, 0, 0, 1, 0 }, new int[] { 0, 5, 10, 15, 20, 25, 30 });
    Assert.Equal(0, tvc.Q(3)); // return 0, At time 3, the votes are [0], and 0 is leading.
    Assert.Equal(1, tvc.Q(12)); // return 1, At time 12, the votes are [0,1,1], and 1 is leading.
    Assert.Equal(1, tvc.Q(25)); // return 1, At time 25, the votes are [0,1,1,0,0,1], and 1 is leading (as ties go to the most recent vote.)
    Assert.Equal(0, tvc.Q(15)); // return 0
    Assert.Equal(0, tvc.Q(24)); // return 0
    Assert.Equal(1, tvc.Q(8)); // return 1
  }
}