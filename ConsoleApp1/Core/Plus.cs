namespace ConsoleApp1.Core
{
    public class Plus: IExpr
    {
        private readonly IExpr _first;
        private readonly IExpr _second;

        public Plus(IExpr first, IExpr second)
        {
            _first = first;
            _second = second;
        }

        public double Evaluate() => _first.Evaluate() + _second.Evaluate();

        public IExpr And(IntDigit expr) => new Plus(_first, _second.And(expr));
        public IExpr CreateBy(IntDigit expr) => new Plus(_first, new By(_second, expr));
    }
}