using MathematicalExpressionsCalculator.Library.Validation;
using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Utilities
{
    public static class Factory
    {
        public static IExpressionValidator CreateExpressionValidator()
        {
            return new ExpressionValidator();
        }

        public static IExpressionSubject CreateExpressionSubject(string inputExpression)
        {
            return new ExpressionSubject(inputExpression);
        }

        public static IObserver CreateDivisionObserver()
        {
            return new DivisionObserver();
        }

        public static IObserver CreateMultiplicationObserver()
        {
            return new MultiplicationObserver();
        }

        public static IObserver CreateAdditionObserver()
        {
            return new AdditionObserver();
        }

        public static IObserver CreateSubtractionObserver()
        {
            return new SubtractionObserver();
        }
    }
}
