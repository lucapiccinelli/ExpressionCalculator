namespace ConsoleApp1.Core
{
    public interface IMonoid
    {
        public IMonoid And(IntDigit expr);
        public IExpr ToExpression();
    }
}