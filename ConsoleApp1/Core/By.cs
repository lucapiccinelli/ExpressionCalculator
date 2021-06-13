namespace ConsoleApp1.Core
{
    public class By: IExpr
    {
        private readonly IExpr _first;
        private readonly IExpr _second;

        public By(IExpr first, IExpr second)
        {
            _first = first;
            _second = second;
        }

        public double Evaluate() => _first.Evaluate() * _second.Evaluate();

        public IExpr And(IntDigit expr) => new By(_first, _second.And(expr));

        public IExpr CreateBy(IntDigit expr) => new By(this, expr);
    }
}