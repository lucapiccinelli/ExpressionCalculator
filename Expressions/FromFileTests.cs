using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleApp1.Core;
using Xunit;

namespace Expressions
{
    public class FromFileTests
    {
        [Fact]
        public void CanReadExpressions_FromFile()
        {
            const string filename = "expressions.txt";
            string firstExpression = "5+2*4";
            string secondExpression = "12-2";
            var lines = new List<string>
            {
                firstExpression,
                secondExpression
            };
            File.WriteAllLines(filename, lines);

            var expr = Expression.FromFile(filename);
            Assert.Equal(new ConsoleApp1.Core.Expressions(Expression.Of(firstExpression), Expression.Of(secondExpression)), expr);
        }
    }
}
