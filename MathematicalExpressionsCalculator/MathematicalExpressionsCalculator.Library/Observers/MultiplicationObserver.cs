using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public class MultiplicationObserver : IObserver
    {
        public void Update(IExpressionSubject subject)
        {
            if ((subject as ExpressionSubject).State == ExpressionSubjectState.Multiplication)
            {
                subject.Stack.Push((subject.A * subject.B).ToString());
            }
        }
    }
}
