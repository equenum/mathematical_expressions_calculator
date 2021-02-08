using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public interface IObserver
    {
        void Update(IExpressionSubject subject);
    }
}
