using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public enum ExpressionSubjectState
    {
        Default = -0,
        Addition = 1,
        Subtraction = 2,
        Multiplication = 3,
        Division = 4
    }
}
