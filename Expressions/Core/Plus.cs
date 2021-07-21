using System;

namespace Expressions.Core
{
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

        public IMonoid And(IntDigit expr) => ExpandDigit(expr);
        public IExpr ToExpression() => this;
        public IExpr Subtract(IExpr expr) => new Minus(this, expr);

        public IExpr ExpandDigit(IntDigit expr) => new Plus(_first, _second.ExpandDigit(expr));
        public IExpr Multiply(IExpr expr) => new Plus(_first, new By(_second, expr));
        public IExpr Add(IExpr expr) => new Plus(this, expr);

        protected bool Equals(Plus other)
        {
            return Equals(_first, other._first) && Equals(_second, other._second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Plus) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_first, _second);
        }
    }
}