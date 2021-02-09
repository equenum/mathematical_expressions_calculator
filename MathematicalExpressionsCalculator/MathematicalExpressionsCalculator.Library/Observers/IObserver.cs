using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    /// <summary>
    /// Represents an observer interface.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the state of the expression subject to which it is attached. 
        /// </summary>
        /// <param name="subject">Expression subject.</param>
        void Update(IExpressionSubject subject);
    }
}
