using ConsoleApp1.Core;
using Xunit;

namespace Expressions
{
    public class OperationsOnExpressionsTests: IClassFixture<WithFileFixture> {
        private readonly WithFileFixture _fixture;

        public OperationsOnExpressionsTests(WithFileFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanSumExpressions()
        {
            var expr = Expression.FromFile(_fixture.Filename);
            Assert.Equal(23, expr.Sum());
        }

    }
}