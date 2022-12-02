using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StairMaster.Core.Tests
{
  public class StairCalculatorTests
  {
    [Theory]
    [MemberData(nameof(CalculateData))]
    public void Calculate_GivenValidString_ReturnsExpectedResult(string stairs, int expectedValue)
    {
      Assert.Equal(expectedValue, StairCalculator.Calculate(stairs));
    }

    [Theory]
    [MemberData(nameof(FirstBasementData))]
    public void FindFirstBasement_GivenValidString_ReturnsExpectedResult(string stairs, int expectedValue)
    {
      Assert.Equal(expectedValue, StairCalculator.FindFirstBasement(stairs));
    }

    public static IEnumerable<object[]> FirstBasementData
    {
      get
      {
        yield return new object[]
        {
          ")",
          1
        };

        yield return new object[]
        {
          "()())",
          5
        };
      }
    }

    public static IEnumerable<object[]> CalculateData
    {
      get
      {
        yield return new object[]
        {
          "(())",
          0
        };

        yield return new object[]
        {
          "()()",
          0
        };

        yield return new object[]
        {
          "(((",
          3
        };

        yield return new object[]
        {
          "(()(()(",
          3
        };

        yield return new object[]
        {
          "))(((((",
          3
        };

        yield return new object[]
        {
          "())",
          -1
        };

        yield return new object[]
        {
          "))(",
          -1
        };

        yield return new object[]
        {
          ")))",
          -3
        };

        yield return new object[]
        {
          ")())())",
          -3
        };
      }
    } 
  }
}
