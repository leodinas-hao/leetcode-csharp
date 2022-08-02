using LeetCode.SeatReservationManager;

namespace tests;

public class SeatReservationManagerTests
{
  [Fact]
  public void Test1()
  {
    SeatManager seatManager = new SeatManager(5); // Initializes a SeatManager with 5 seats.
    Assert.Equal(1, seatManager.Reserve());    // All seats are available, so return the lowest numbered seat, which is 1.
    Assert.Equal(2, seatManager.Reserve());    // The available seats are [2,3,4,5], so return the lowest of them, which is 2.
    seatManager.Unreserve(2); // Unreserve seat 2, so now the available seats are [2,3,4,5].
    Assert.Equal(2, seatManager.Reserve());    // The available seats are [2,3,4,5], so return the lowest of them, which is 2.
    Assert.Equal(3, seatManager.Reserve());    // The available seats are [3,4,5], so return the lowest of them, which is 3.
    Assert.Equal(4, seatManager.Reserve());    // The available seats are [4,5], so return the lowest of them, which is 4.
    Assert.Equal(5, seatManager.Reserve());    // The only available seat is seat 5, so return 5.
    seatManager.Unreserve(5); // Unreserve seat 5, so now the available seats are [5].
  }
}