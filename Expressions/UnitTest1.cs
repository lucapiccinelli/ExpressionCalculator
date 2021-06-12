using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using static System.Int32;

namespace Expressions
{
    public class ExpressionsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new IntDigit(5), 5.0 };
            yield return new object[] { new Plus(new IntDigit(5), new IntDigit(1)), 6.0 };
            yield return new object[] { new Minus(new IntDigit(5), new IntDigit(1)), 4.0 };
            yield return new object[] { new Plus(new IntDigit(5), new Plus(new IntDigit(1), new IntDigit(2))), 8.0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnitTest1
    {
        [Theory]
        [ClassData(typeof(ExpressionsTestData))]
        public void CanEvaluateAnExpression(IExpr expression, double result)
        {
            Assert.Equal(expression.Evaluate(), result);
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
        public void CanParseAnExpression(string expression, double expectedResult)
        {
            Assert.Equal(expectedResult, IExpr.Of(expression).Evaluate());
        }
    }

    public class Plus: IExpr
    {
        private readonly IExpr _first;
        private readonly IExpr _second;

        public Plus(IExpr first, IExpr second)
        {
            _first = first;
            _second = second;
        }

        public double Evaluate() => _first.Evaluate() + _second.Evaluate();

        public IExpr And(IntDigit expr) => new Plus(_first, _second.And(expr));
    }

    public class Minus: IExpr
    {
        private readonly IExpr _first;
        private readonly IExpr _second;

        public Minus(IExpr first, IExpr second)
        {
            _first = first;
            _second = second;
        }

        public double Evaluate() => _first.Evaluate() - _second.Evaluate();

        public IExpr And(IntDigit expr) => new Minus(_first, _second.And(expr));
    }

    public class IntDigit : IExpr
    {
        private readonly int _value;

        public IntDigit(int value)
        {
            _value = value;
        }

        public IntDigit(double value)
        {
            _value = (int) value;
        }

        public double Evaluate() => _value;
        public IExpr And(IntDigit expr)
        {
            return new IntDigit(_value * 10 + expr._value);
        }
    }

    public interface IExpr
    {
        public static IExpr Of(string input) =>
            input.Aggregate(new EmptyExpression() as IExpr, (expression, c) =>
            {
                if (char.IsDigit(c)) return expression.And(new IntDigit(Parse(c.ToString())));
                if (char.IsWhiteSpace(c)) return expression;
                return new Operator(c, expression);
            });

        double Evaluate();
        public IExpr And(IntDigit expr);
    }

    public class Operator : IExpr
    {
        private readonly char _c;
        private readonly IExpr _expression;

        public Operator(in char c, IExpr expression)
        {
            _c = c;
            _expression = expression;
        }

        public double Evaluate()
        {
            return 0;
        }

        public IExpr And(IntDigit expr)
        {
            switch (_c)
            {
                case '+':
                    return new Plus(_expression, expr);
                case '-':
                    return new Minus(_expression, expr);

            }
            throw new Exception("booom");
        }
    }

    public class EmptyExpression : IExpr
    {
        public double Evaluate() => 0;

        public IExpr And(IntDigit expr)
        {
            return expr;
        }
    }
}
