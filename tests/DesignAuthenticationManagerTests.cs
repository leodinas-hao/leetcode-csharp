using LeetCode.DesignAuthenticationManager;

namespace tests;

public class DesignAuthenticationManagerTests
{
  [Fact]
  public void Test1()
  {
    // Constructs the AuthenticationManager with timeToLive = 5 seconds.
    AuthenticationManager auth = new AuthenticationManager(5);
    // No token exists with tokenId "aaa" at time 1, so nothing happens.
    auth.Renew("aaa", 1);
    // Generates a new token with tokenId "aaa" at time 2.
    auth.Generate("aaa", 2);
    // The token with tokenId "aaa" is the only unexpired one at time 6, so return 1.
    Assert.Equal(1, auth.CountUnexpiredTokens(6));
    // Generates a new token with tokenId "bbb" at time 7.
    auth.Generate("bbb", 7);
    // The token with tokenId "aaa" expired at time 7, and 8 >= 7, so at time 8 the renew request is ignored, and nothing happens.
    auth.Renew("aaa", 8);
    // The token with tokenId "bbb" is unexpired at time 10, so the renew request is fulfilled and now the token will expire at time 15.
    auth.Renew("bbb", 10);
    // The token with tokenId "bbb" expires at time 15, and the token with tokenId "aaa" expired at time 7, so currently no token is unexpired, so return 0.
    Assert.Equal(0, auth.CountUnexpiredTokens(15));
  }
}