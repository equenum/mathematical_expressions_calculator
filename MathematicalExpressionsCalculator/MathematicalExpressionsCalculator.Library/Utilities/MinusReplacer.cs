using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.ExpressionHandling
{
    /// <summary>
    /// Representa an expression minus replacer.
    /// </summary>
    public class MinusReplacer
    {
        /// <summary>
        /// Replaces all negative arguments with their positive versions in accordance with mathematical rules.
        /// </summary>
        /// <param name="expression">Input expression.</param>
        /// <param name="operators">A list of supported mathematic operators.</param>
        /// <returns>An expression without negative arguments.</returns>
        public static string ReplaceMinus(string expression, List<string> operators)
        {
            StringBuilder result = new StringBuilder();

            int startingPoint = 0;

            if (expression[0] == '-')
            {
                for (int i = 1; i < expression.Length; i++)
                {
                    if (operators.Contains(expression[i].ToString()))
                    {
                        var tmp = expression.Substring(0, i);
                        result.Append("(0" + tmp + ")");
                        startingPoint = i;
                        break;
                    }

                    // in case an expression consists of a
                    // single negative argument
                    if (i == expression.Length - 1)
                    {
                        var tmp = expression.Substring(0);
                        result.Append("(0" + tmp + ")");
                    }
                }
            }

            for (int i = startingPoint; i < expression.Length; i++)
            {
                if (expression[i] == '-' && expression[i - 1] != ')' && operators.Contains(expression[i - 1].ToString()))
                {
                    for (int j = i + 1; j < expression.Length; j++)
                    {
                        if (operators.Contains(expression[j].ToString()))
                        {
                            var tmp = expression.Substring(i, j - i);
                            result.Append("(0" + tmp + ")");
                            i = j - 1;
                            break;
                        }

                        // in case the last argument is negative
                        if (j == expression.Length - 1)
                        {
                            var tmp = expression.Substring(i);
                            result.Append("(0" + tmp + ")");
                            i = j;
                        }
                    }
                }
                else
                {
                    result.Append(expression[i]);
                }
            }

            return result.ToString();
        }
    }
}
