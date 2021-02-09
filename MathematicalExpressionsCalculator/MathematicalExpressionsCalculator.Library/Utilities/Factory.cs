using MathematicalExpressionsCalculator.Library.Validation;
using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Utilities
{
    /// <summary>
    /// Representa a class factory.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates an instance of ExpressionValidator.
        /// </summary>
        /// <returns>An instance of ExpressionValidator.</returns>
        public static IExpressionValidator CreateExpressionValidator()
        {
            return new ExpressionValidator();
        }

        /// <summary>
        /// Creates an instance of ExpressionSubject.
        /// </summary>
        /// <param name="inputExpression">Input expression.</param>
        /// <returns>An instance of ExpressionSubject.</returns>
        public static IExpressionSubject CreateExpressionSubject(string inputExpression)
        {
            return new ExpressionSubject(inputExpression);
        }

        /// <summary>
        /// Creates an instance of DivisionObserver.
        /// </summary>
        /// <returns>An instance of DivisionObserver.</returns>
        public static IObserver CreateDivisionObserver()
        {
            return new DivisionObserver();
        }

        /// <summary>
        /// Creates an instance of MultiplicationObserver.
        /// </summary>
        /// <returns>An instance of MultiplicationObserver.</returns>
        public static IObserver CreateMultiplicationObserver()
        {
            return new MultiplicationObserver();
        }

        /// <summary>
        /// Creates an instance of AdditionObserver.
        /// </summary>
        /// <returns>An instance of AdditionObserver.</returns>
        public static IObserver CreateAdditionObserver()
        {
            return new AdditionObserver();
        }

        /// <summary>
        /// Creates an instance of SubtractionObserver.
        /// </summary>
        /// <returns>An instance of SubtractionObserver.</returns>
        public static IObserver CreateSubtractionObserver()
        {
            return new SubtractionObserver();
        }
    }
}
