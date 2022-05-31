using LeetCode.SimpleBankSystem;

namespace tests;

public class SimpleBankSystemTests
{
  [Fact]
  public void Test1()
  {
    var balance = new long[] { 10L, 100L, 20L, 50L, 30L };
    var bank = new Bank(balance);

    Assert.True(bank.Withdraw(3, 10L));
    Assert.True(bank.Transfer(5, 1, 20L));
    Assert.True(bank.Deposit(5, 20L));
    Assert.False(bank.Transfer(3, 4, 15L));
    Assert.False(bank.Withdraw(10, 50L));
  }
}
