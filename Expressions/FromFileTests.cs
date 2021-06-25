using System.Linq;
using System.Text;
using ConsoleApp1.Core;
using Xunit;

namespace Expressions
{
    public class FromFileTests: IClassFixture<WithFileFixture>
    {
        private readonly WithFileFixture _fixture;
        private readonly string _filename;

        public FromFileTests(WithFileFixture fixture)
        {
            _fixture = fixture;
            _filename = fixture.Filename;
        }

        [Fact]
        public void CanReadExpressions_FromFile()
        {
            var expr = Expression.FromFile(_filename);
            var expected = new ConsoleApp1.Core.Expressions(
                Expression.Of(_fixture.FirstExpression), 
                Expression.Of(_fixture.SecondExpression));
            Assert.Equal(expected, expr);
        }
    }
}
