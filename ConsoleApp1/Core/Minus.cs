using System;

namespace ConsoleApp1.Core
{
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
        public IExpr CreateBy(IntDigit expr) => new Minus(_first, new By(_second, expr));

        protected bool Equals(Minus other)
        {
            return Equals(_first, other._first) && Equals(_second, other._second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Minus) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_first, _second);
        }
    }
}