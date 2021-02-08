using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.ExpressionHandling
{
    public class NotationConverter
    {
        public static string[] ConvertToPostfix(string expression, List<string> operators)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();

            expression = MinusReplacer.ReplaceMinus(expression.Trim(), operators);

            foreach (string element in ExpressionSeparator.Separate(expression.Trim(), operators))
            {
                if (operators.Contains(element))
                {
                    if (stack.Count > 0 && element != "(")
                    {
                        if (element == ")")
                        {
                            string s = stack.Pop();

                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(element) >= GetPriority(stack.Peek()))
                        {
                            stack.Push(element);
                        }
                        else
                        {
                            while (stack.Count > 0 && GetPriority(element) < GetPriority(stack.Peek()))
                            {
                                outputSeparated.Add(stack.Pop());
                            }

                            stack.Push(element);
                        }
                    }
                    else
                    {
                        stack.Push(element);
                    }
                }
                else
                {
                    outputSeparated.Add(element);
                }
            }

            if (stack.Count > 0)
            {
                foreach (string stackElement in stack)
                {
                    outputSeparated.Add(stackElement);
                }
            }

            return outputSeparated.ToArray();
        }

        private static byte GetPriority(string @operator)
        {
            switch (@operator)
            {
                case "(":
                    return 1;
                case ")":
                    return 2;
                case "+":
                case "-":
                    return 3;
                case "*":
                case "/":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
