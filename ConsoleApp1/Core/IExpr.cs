using System;
using System.Linq;

namespace ConsoleApp1.Core
{
    public interface IExpr: IMonoid
    {
        double Evaluate();
        IExpr CreateBy(IntDigit expr);

        public IExpr ExpandDigit(IntDigit expr);
    }
}