using System;

namespace ConsoleApp1.Core
{
    public class EmptyExpression : IExpr
    {
        public double Evaluate() => throw new Exception("Empty Expression can't be evaluated");

        public IMonoid And(IntDigit expr) => ExpandDigit(expr);
        public IExpr ToExpression() => this;

        public IExpr Multiply(IExpr expr) => new By(new IntDigit(1), expr);
        public IExpr Add(IExpr expr) => new Plus(new IntDigit(0), expr);
        public IExpr Subtract(IExpr expr) => new Minus(new IntDigit(0), expr);

        public IExpr ExpandDigit(IntDigit expr) => expr;
    }
}