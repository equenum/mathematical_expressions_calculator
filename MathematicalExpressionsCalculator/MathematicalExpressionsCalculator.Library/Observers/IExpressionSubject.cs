using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public interface IExpressionSubject : ISubject
    {
        public string[] InfixNotationValue { get; }
        public string[] PostfixNotationValue { get; }
        public string Result { get; }
        public Stack<string> Stack { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public string Calculate();
    }
}
