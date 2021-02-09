using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.ExpressionHandling
{
    /// <summary>
    /// Represents an expression separetor.
    /// </summary>
    public class ExpressionSeparator
    {
        /// <summary>
        /// Separates string expression into separate single string elements.
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <param name="operators">A list of supported mathematical operators.</param>
        /// <returns>Separated expression.</returns>
        public static IEnumerable<string> Separate(string expression, List<string> operators)
        {
            int positionCounter = 0;

            while (positionCounter < expression.Length)
            {
                string s = string.Empty + expression[positionCounter];

                if (operators.Contains(expression[positionCounter].ToString()) == false)
                {
                    for (int i = positionCounter + 1; i < expression.Length && (Char.IsDigit(expression[i]) || expression[i] == '.'); i++)
                    {
                        s += expression[i];
                    }
                }

                yield return s;
                positionCounter += s.Length;
            }
        }
    }
}
