using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.ExpressionHandling
{
    public class MinusReplacer
    {
        public static string ReplaceMinus(string input, List<string> operators)
        {
            StringBuilder result = new StringBuilder(); // TODO - Create a field Result. Assing new string builder in the ctor. DI maybe?

            int startingPoint = 0;

            if (input[0] == '-')
            {
                for (int i = 1; i < input.Length; i++)
                {
                    if (operators.Contains(input[i].ToString()))
                    {
                        var tmp = input.Substring(0, i);
                        result.Append("(0" + tmp + ")");
                        startingPoint = i;
                        break;
                    }

                    // in case an expression consists of sione
                    // single negative argument
                    if (i == input.Length - 1)
                    {
                        var tmp = input.Substring(0);
                        result.Append("(0" + tmp + ")");
                    }
                }
            }

            for (int i = startingPoint; i < input.Length; i++)
            {
                if (input[i] == '-' && input[i - 1] != ')' && operators.Contains(input[i - 1].ToString()))
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (operators.Contains(input[j].ToString()))
                        {
                            var tmp = input.Substring(i, j - i);
                            result.Append("(0" + tmp + ")");
                            i = j - 1;
                            break;
                        }

                        // in case the last argument is negative
                        if (j == input.Length - 1)
                        {
                            var tmp = input.Substring(i);
                            result.Append("(0" + tmp + ")");
                            i = j;
                        }
                    }
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }
    }
}
