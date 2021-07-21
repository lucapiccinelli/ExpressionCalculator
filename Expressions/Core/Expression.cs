using System.IO;
using System.Linq;

namespace Expressions.Core
{
    public static class Expression
    {
        public static IExpr Of(string input) =>
            input.Aggregate(EmptyMonoid, (monoid, c) =>
            {
                if (char.IsDigit(c)) return monoid.And(new IntDigit(int.Parse(c.ToString())));
                if (char.IsWhiteSpace(c)) return monoid;
                return new Operator(c, monoid.ToExpression());
            }).ToExpression();

        public static Expressions FromFile(string expressionsTxt)
        {
            var expressions = File
                .ReadAllLines(expressionsTxt)
                .Select(Expression.Of)
                .ToArray();

            return new Expressions(expressions);
        }

        public static IExpr Empty => new EmptyExpression();
        public static IMonoid EmptyMonoid => Empty;
    }
}