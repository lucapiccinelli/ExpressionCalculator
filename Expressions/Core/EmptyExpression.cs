using Expressions.Exceptions;

namespace Expressions.Core
{
    public class EmptyExpression : IExpr
    {
        public double Evaluate() => throw new InvalidExpressionException("Empty Expression can't be evaluated");

        public IMonoid And(IntDigit expr) => ExpandDigit(expr);
        public IExpr ToExpression() => throw new InvalidExpressionException("An Expression can' be empty");

        public IExpr Multiply(IExpr expr) => new By(new IntDigit(1), expr);
        public IExpr Add(IExpr expr) => new Plus(new IntDigit(0), expr);
        public IExpr Subtract(IExpr expr) => new Minus(new IntDigit(0), expr);

        public IExpr ExpandDigit(IntDigit expr) => expr;
    }
}