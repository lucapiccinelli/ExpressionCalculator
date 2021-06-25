using System;

namespace ConsoleApp1.Core
{
    public class By: IExpr
    {
        private readonly IExpr _first;
        private readonly IExpr _second;

        public By(IExpr first, IExpr second)
        {
            _first = first;
            _second = second;
        }

        public double Evaluate() => _first.Evaluate() * _second.Evaluate();

        public IMonoid And(IntDigit expr) => ExpandDigit(expr);
        public IExpr ToExpression() => this;
        public IExpr ExpandDigit(IntDigit expr) => new By(_first, _second.ExpandDigit(expr));

        public IExpr CreateBy(IntDigit expr) => new By(this, expr);

        protected bool Equals(By other)
        {
            return Equals(_first, other._first) && Equals(_second, other._second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((By) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_first, _second);
        }
    }
}