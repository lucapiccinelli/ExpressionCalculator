namespace ConsoleApp1.Core
{
    public class EmptyExpression : IExpr
    {
        public double Evaluate() => 0;

        public IMonoid And(IntDigit expr) => ExpandDigit(expr);
        public IExpr ToExpression() => this;

        public IExpr CreateBy(IExpr expr) => new By(new IntDigit(1), expr);
        public IExpr ExpandDigit(IntDigit expr) => expr;
    }
}