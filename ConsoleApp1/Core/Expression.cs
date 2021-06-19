using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.Core
{
    public static class Expression
    {
        public static IExpr Of(string input) =>
            input.Aggregate(new EmptyExpression() as IExpr, (expression, c) =>
            {
                if (char.IsDigit(c)) return expression.And(new IntDigit(int.Parse(c.ToString())));
                if (char.IsWhiteSpace(c)) return expression;
                return new Operator(c, expression);
            });

        public static Expressions FromFile(string expressionsTxt)
        {
            var expressions = File
                .ReadAllLines(expressionsTxt)
                .Select(Expression.Of)
                .ToArray();

            return new Expressions(expressions);
        }
    }
}