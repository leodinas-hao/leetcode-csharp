namespace tests;

public class BitwiseOperatorsTests
{
  [Theory]
  [InlineData(0b100, 0b110, 0b100)]
  public void BitwiseAnd(int a, int b, int expect)
  {
    // if both bits 1 then the result is 1
    var result = a & b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b100, 0b110, 0b110)]
  public void BitwiseOr(int a, int b, int expect)
  {
    // if either bit is 1, then it's 1
    var result = a | b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b100, 0b110, 0b010)]
  public void BitwiseXOr(int a, int b, int expect)
  {
    // if both bits are same, result is 0; otherwise 1
    var result = a ^ b;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b100, -0b101)]
  public void BitwiseComplement(int a, int expect)
  {
    // https://www.programiz.com/csharp-programming/bitwise-operators
    // operates on one number & inverts each bit (1 to 0 or 0 to 1)
    var result = ~a;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b11, 1, 0b110)]
  [InlineData(0b101, 2, 0b10100)]
  public void BitwiseLeftShift(int a, int shift, int expect)
  {
    // shifts a number to the left by a specified number of bits
    // zeroes are added to the least significant bits
    var result = a << shift;
    Assert.Equal(expect, result);
  }

  [Theory]
  [InlineData(0b11, 1, 0b01)]
  [InlineData(0b101, 2, 0b001)]
  public void BitwiseRightShift(int a, int shift, int expect)
  {
    // shifts a number to the right by a specified number of bits
    // the first operand is shifted to right by the number of bits specified by second operand
    var result = a >> shift;
    Assert.Equal(expect, result);
  }
}
