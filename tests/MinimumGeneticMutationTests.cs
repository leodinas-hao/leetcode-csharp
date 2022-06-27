using LeetCode.MinimumGeneticMutation;

namespace tests;

public class MinimumGeneticMutationTests
{
  [Theory]
  [InlineData("AACCGGTT", "AACCGGTA", new string[] { "AACCGGTA" }, 1)]
  [InlineData("AACCGGTT", "AAACGGTA", new string[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" }, 2)]
  [InlineData("AAAAACCC", "AACCCCCC", new string[] { "AAAACCCC", "AAACCCCC", "AACCCCCC" }, 3)]
  public void Test1(string start, string end, string[] bank, int expect)
  {
    Assert.Equal(expect, new Solution().MinMutation(start, end, bank));
  }
}