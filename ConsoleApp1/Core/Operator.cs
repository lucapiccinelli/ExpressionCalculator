using System.Data;

namespace ConsoleApp1.Core
{
    public class Operator : IMonoid
    {
        private readonly char _c;
        private readonly IExpr _expression;

        public Operator(in char c, IExpr expression)
        {
            _c = c;
            _expression = expression;
        }

        public IMonoid And(IntDigit expr) =>
            _c switch
            {
                '+' => _expression.Add(expr),
                '-' => _expression.Subtract(expr),
                '*' => _expression.Multiply(expr),
                _ => _expression.And(expr)
            };

        public IExpr ToExpression()
        {
            throw new InvalidExpressionException();
        }
    }
}