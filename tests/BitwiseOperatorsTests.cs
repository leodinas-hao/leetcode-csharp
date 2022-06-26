namespace tests;

public class BitwiseOperatorsTests
{
  [Theory]
  [InlineData(0b100, 0b110, 0b100)]
  public void BitwiseAnd(uint a, uint b, uint expect)
  {
    // if both bits 1 then the result is 1
    var result = a & b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b100, 0b110, 0b110)]
  public void BitwiseOr(uint a, uint b, uint expect)
  {
    // if either bit is 1, then it's 1
    // in another word, both bits are 0, then it's 0
    var result = a | b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b100, 0b110, 0b010)]
  public void BitwiseXOr(uint a, uint b, uint expect)
  {
    // if both bits are same, result is 0; otherwise 1
    var result = a ^ b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b0000_1111_0000_1111_0000_1111_0000_1100, 0b1111_0000_1111_0000_1111_0000_1111_0011)]
  public void BitwiseComplement(uint a, uint expect)
  {
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-
    // operates on one number & inverts each bit (1 to 0 or 0 to 1)
    var result = ~a;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b1100_1001_0000_0000_0000_0000_0001_0001, 4, 0b1001_0000_0000_0000_0000_0001_0001_0000)]
  [InlineData(0b0000_0000_0000_0000_0000_0000_1110_0111, 4, 0b0000_0000_0000_0000_0000_1110_0111_0000)]
  [InlineData(0b1100, 2, 0b110000)]
  [InlineData(0b1101, 2, 0b110100)]
  public void BitwiseLeftShift(uint a, int shift, uint expect)
  {
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-
    // shifts a number to the left by a specified number of bits
    // discards the high-order bits that are outside the range of the result type 
    // and sets the low-order empty bit positions to zero
    var result = a << shift;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b10, 1, 0b1)]
  [InlineData(0b100, 1, 0b10)]
  [InlineData(0b101, 2, 0b1)]
  [InlineData(0b1001, 2, 0b10)]
  [InlineData(0b0000_0000_0000_0000_0000_0000_1110_0111, 4, 0b0000_0000_0000_0000_0000_0000_0000_1110)]
  public void BitwiseRightShift(uint a, int shift, uint expect)
  {
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#right-shift-operator-
    // shifts a number to the right by a specified number of bits
    // discards the low-order bits
    var result = a >> shift;
    Assert.Equal(expect, result);
  }
}
