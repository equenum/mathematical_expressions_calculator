using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public class AdditionObserver : IObserver
    {
        public void Update(IExpressionSubject subject)
        {
            if ((subject as ExpressionSubject).State == ExpressionSubjectState.Addition)
            {
                subject.Stack.Push((subject.A + subject.B).ToString());
            }
        }
    }
}
