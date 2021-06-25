using System;
using System.Linq;

namespace ConsoleApp1.Core
{
    public interface IExpr: IMonoid
    {
        double Evaluate();
        IExpr CreateBy(IExpr expr);

        public IExpr ExpandDigit(IntDigit expr);
    }
}