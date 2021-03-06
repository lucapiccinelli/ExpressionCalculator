using System;
using System.Linq;

namespace Expressions.Core
{
    public class Expressions
    {
        private readonly IExpr[] _expressions;

        public Expressions(params IExpr[] expressions)
        {
            _expressions = expressions;
        }

        protected bool Equals(Expressions other)
        {
            return _expressions.SequenceEqual(other._expressions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Expressions) obj);
        }

        public override int GetHashCode()
        {
            return (_expressions != null ? _expressions.GetHashCode() : 0);
        }

        public override string ToString() => _expressions.Aggregate("", (acc, expr ) => $"{acc}, {expr}");

        public double Sum() =>
            Reduce((acc, expr) => acc.Add(expr));

        public double Multiply() =>
            Reduce((acc, expr) => acc.Multiply(expr));

        private double Reduce(Func<IExpr, IExpr, IExpr> reducer) =>
            _expressions
                .Aggregate(Expression.Empty, reducer)
                .Evaluate();
    }
}