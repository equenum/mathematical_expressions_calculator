using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Validation
{
    public class ExpressionValidator
    {
        private static readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/", "." };

        public string Value { get; set; }

        public ExpressionValidator(string value)
        {
            Value = value;
        }

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

            for (int i = 1; i < Value.Length - 1; i++)
            {
                if (_operators.Contains(Char.ToString(Value[i])))
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
            for (int i = 0; i < Value.Length; i++)
            {
                if (Char.IsDigit(Value[i]) == false && _operators.Contains(Char.ToString(Value[i])) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool DivisionByZeroCheck()
        {
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value[i] == '/')
                {
                    if (Value[i + 1] == '0')
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
