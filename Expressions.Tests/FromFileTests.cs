using Expressions.Core;
using Xunit;

namespace Expressions.Tests
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
            var expected = new Core.Expressions(
                Expression.Of(_fixture.FirstExpression), 
                Expression.Of(_fixture.SecondExpression));
            Assert.Equal(expected, expr);
        }
    }
}
