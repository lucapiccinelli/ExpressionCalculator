namespace ConsoleApp1.Core
{
    public class EmptyExpression : IExpr
    {
        public double Evaluate() => 0;

        public IExpr And(IntDigit expr) => expr;
        public IExpr CreateBy(IntDigit expr) => new By(new IntDigit(1), expr);
    }
}