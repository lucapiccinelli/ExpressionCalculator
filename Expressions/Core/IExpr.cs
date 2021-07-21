namespace Expressions.Core
{
    public interface IExpr: IMonoid
    {
        double Evaluate();
        IExpr Multiply(IExpr expr);
        IExpr Add(IExpr expr);
        IExpr Subtract(IExpr expr);

        public IExpr ExpandDigit(IntDigit expr);
    }
}