using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using static System.Int32;

namespace Expressions
{
    public class UnitTest1
    {
        [Fact]
        public void CanParseADigit()
        {
            var result = IExpr.Of("5");

            Assert.Equal(new IntDigit(5).Evaluate(), result.Evaluate());
        }

        [Fact]
        public void CanParseASum()
        {
            var result = IExpr.Of("5+1");

            Assert.Equal(new Plus(new IntDigit(5), new IntDigit(1)).Evaluate(), result.Evaluate());
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

        public double Evaluate()
        {
            return _first.Evaluate() + _second.Evaluate();
        }

        public IExpr And(IntDigit expr)
        {
            throw new System.NotImplementedException();
        }
    }

    public class IntDigit : IExpr
    {
        private readonly int _value;

        public IntDigit(int value)
        {
            _value = value;
        }

        public double Evaluate() => _value;
        public IExpr And(IntDigit expr)
        {
            return expr;
        }
    }

    public interface IExpr
    {
        public static IExpr Of(string input) =>
            input.Aggregate(new EmptyExpression() as IExpr, (expression, c) =>
            {
                if (char.IsDigit(c)) return expression.And(new IntDigit(Parse(c.ToString())));
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
            return new Plus(_expression, expr);
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
