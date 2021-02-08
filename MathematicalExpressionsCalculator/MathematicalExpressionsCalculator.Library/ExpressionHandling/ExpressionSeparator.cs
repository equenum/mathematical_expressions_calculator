using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.ExpressionHandling
{
    public class ExpressionSeparator
    {
        public static IEnumerable<string> Separate(string input, List<string> operators)
        {
            int positionCounter = 0;

            while (positionCounter < input.Length)
            {
                string s = string.Empty + input[positionCounter];

                if (operators.Contains(input[positionCounter].ToString()) == false)
                {
                    for (int i = positionCounter + 1; i < input.Length && (Char.IsDigit(input[i]) || input[i] == '.'); i++)
                    {
                        s += input[i];
                    }
                }

                yield return s;
                positionCounter += s.Length;
            }
        }
    }
}
