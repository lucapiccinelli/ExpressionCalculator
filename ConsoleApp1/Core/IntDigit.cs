namespace ConsoleApp1.Core
{
    public class IntDigit : IExpr
    {
        private readonly int _value;

        public IntDigit(int value)
        {
            _value = value;
        }

        public double Evaluate() => _value;
        public IExpr And(IntDigit expr)
        {
            return new IntDigit(_value * 10 + expr._value);
        }

        public IExpr CreateBy(IntDigit expr) => new By(this, expr);
    }
}