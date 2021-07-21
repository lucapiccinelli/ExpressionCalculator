using Expressions.Core;
using Xunit;

namespace Expressions.Tests
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

        [Fact]
        public void CanMultiplyExpressions()
        {
            var expr = Expression.FromFile(_fixture.Filename);
            Assert.Equal(130, expr.Multiply());
        }

    }
}