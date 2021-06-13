namespace ConsoleApp1.Core
{
    public class Operator : IExpr
    {
        private readonly char _c;
        private readonly IExpr _expression;

        public Operator(in char c, IExpr expression)
        {
            _c = c;
            _expression = expression;
        }

        public double Evaluate() => 0;

        public IExpr And(IntDigit expr) =>
            _c switch
            {
                '+' => new Plus(_expression, expr),
                '-' => new Minus(_expression, expr),
                '*' => _expression.CreateBy(expr),
                _ => _expression.And(expr)
            };

        public IExpr CreateBy(IntDigit expr)
        {
            throw new System.NotImplementedException();
        }
    }
}