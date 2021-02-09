using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Validation
{
    public class ExpressionValidator : IExpressionValidator
    {
        private static readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/", "." };

        public string Expression { get; set; }

        public bool Validate()
        {
            if (OperatorsCountCheck() && NotAllowedOperatorsCheck() && DivisionByZeroCheck())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool OperatorsCountCheck()
        {
            int operationCounter = 0;

            for (int i = 1; i < Expression.Length - 1; i++)
            {
                if (_operators.Contains(Char.ToString(Expression[i])))
                {
                    operationCounter++;
                }
            }

            if (operationCounter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NotAllowedOperatorsCheck()
        {
            for (int i = 0; i < Expression.Length; i++)
            {
                if (Char.IsDigit(Expression[i]) == false && _operators.Contains(Char.ToString(Expression[i])) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool DivisionByZeroCheck()
        {
            for (int i = 0; i < Expression.Length; i++)
            {
                if (Expression[i] == '/')
                {
                    if (Expression[i + 1] == '0')
                    {
                        Console.WriteLine("Division by zero is not allowed!");

                        return false;
                    }
                }
            }

            return true;
        }
    }
}
