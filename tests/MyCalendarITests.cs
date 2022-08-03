using LeetCode.MyCalendarI;

namespace tests;

public class MyCalendarITests
{
  [Fact]
  public void Test1()
  {
    var cal = new MyCalendar();
    Assert.True(cal.Book(10, 20)); // return True
    Assert.False(cal.Book(15, 25)); // return False, It can not be booked because time 15 is already booked by another event.
    Assert.True(cal.Book(20, 30)); // return True, The event can be booked, as the first event takes every time less than 20, but not including 20.
  }
}