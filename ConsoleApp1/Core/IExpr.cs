using System;
using System.Linq;

namespace ConsoleApp1.Core
{
    public interface IExpr
    {
        double Evaluate();
        public IExpr And(IntDigit expr);
        IExpr CreateBy(IntDigit expr);
    }
}