using System;
using System.Linq;

namespace ConsoleApp1.Core
{
    public interface IExpr
    {
        public static IExpr Of(string input) =>
            input.Aggregate(new EmptyExpression() as IExpr, (expression, c) =>
            {
                if (char.IsDigit(c)) return expression.And(new IntDigit(int.Parse(c.ToString())));
                if (char.IsWhiteSpace(c)) return expression;
                return new Operator(c, expression);
            });

        double Evaluate();
        public IExpr And(IntDigit expr);
        IExpr CreateBy(IntDigit expr);
    }
}