using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    /// <summary>
    /// Represents an division observer.
    /// </summary>
    public class DivisionObserver : IObserver
    {
        public void Update(IExpressionSubject subject)
        {
            if ((subject as ExpressionSubject).State == ExpressionSubjectState.Division)
            {
                subject.Stack.Push((subject.A / subject.B).ToString());
            }
        }
    }
}
