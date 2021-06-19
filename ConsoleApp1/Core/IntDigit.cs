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

        protected bool Equals(IntDigit other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IntDigit) obj);
        }

        public override int GetHashCode()
        {
            return _value;
        }
    }
}