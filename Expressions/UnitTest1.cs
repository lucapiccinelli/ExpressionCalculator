using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ConsoleApp1.Core;
using Xunit;

namespace Expressions
{
    public class ExpressionsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new IntDigit(5), 5.0 };
            yield return new object[] { new Plus(new IntDigit(5), new IntDigit(1)), 6.0 };
            yield return new object[] { new Minus(new IntDigit(5), new IntDigit(1)), 4.0 };
            yield return new object[] { new By(new IntDigit(2), new IntDigit(3)), 6.0 };
            yield return new object[] { new Plus(new IntDigit(5), new Plus(new IntDigit(1), new IntDigit(2))), 8.0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnitTest1
    {
        public static IEnumerable<object[]> ExpressionsData() => new List<object[]>
        {
            new object[] {new IntDigit(5), 5.0},
            new object[] {new Plus(new IntDigit(5), new IntDigit(1)), 6.0},
            new object[] {new Minus(new IntDigit(5), new IntDigit(1)), 4.0},
            new object[] {new By(new IntDigit(2), new IntDigit(3)), 6.0},
            new object[] {new Plus(new IntDigit(5), new Plus(new IntDigit(1), new IntDigit(2))), 8.0},
        };

        [Theory]
        [MemberData(nameof(ExpressionsData))]
        public void CanEvaluateAnExpression(IExpr expression, double result)
        {
            Assert.Equal(result, expression.Evaluate());
        }

        [Theory]
        [InlineData("5", 5.0)]
        [InlineData("5+1", 6.0)]
        [InlineData("5 + 1", 6.0)]
        [InlineData("11+1", 12.0)]
        [InlineData("1+12", 13.0)]
        [InlineData("234+1", 235.0)]
        [InlineData("234+10", 244.0)]
        [InlineData("1+110", 111)]
        [InlineData("110-1", 109)]
        [InlineData("110-10", 100)]
        [InlineData("1+2+3", 6)]
        [InlineData("1+2-3", 0)]
        [InlineData("1-2+3", 2)]
        [InlineData("1-2+30 - 2", 27)]
        [InlineData("1-2+30 - 20", 9)]
        [InlineData("2*3", 6)]
        [InlineData("2*3+1", 7)]
        [InlineData("2*30+1", 61)]
        [InlineData("1+2*3", 7)]
        [InlineData("7-2*3", 1)]
        [InlineData("70-2*30+4*2-10", 8)]
        [InlineData("2*3-5", 1)]
        [InlineData("2*2*2", 8)]
        public void CanParseAnExpression(string expression, double expectedResult)
        {
            Assert.Equal(expectedResult, IExpr.Of(expression).Evaluate());
        }
    }
}
