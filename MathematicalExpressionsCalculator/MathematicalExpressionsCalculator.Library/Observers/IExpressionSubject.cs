using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    /// <summary>
    /// Represents an expression subject interface.
    /// </summary>
    public interface IExpressionSubject : ISubject
    {
        /// <summary>
        /// Represents expression infix notation value.
        /// </summary>
        public string[] InfixNotationValue { get; }
        /// <summary>
        /// Represents expression postfix notation value.
        /// </summary>
        public string[] PostfixNotationValue { get; }
        /// <summary>
        /// Represents expression result calculation value.
        /// </summary>
        public string Result { get; }
        /// <summary>
        /// This stack is used by Calculate() method in order 
        /// to evaluate postfix notation expression.
        /// </summary>
        public Stack<string> Stack { get; set; }
        /// <summary>
        /// Represents argument "A" during expression result value calculation.
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// Represents argument "B" during expression result value calculation.
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// Calculates expression result value.
        /// </summary>
        /// <returns></returns>
        public string Calculate();
    }
}
