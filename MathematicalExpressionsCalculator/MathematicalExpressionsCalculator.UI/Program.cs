using MathematicalExpressionsCalculator.Library.Observers;
using MathematicalExpressionsCalculator.Library.Repositories;
using MathematicalExpressionsCalculator.Library.Validation;
using System;
using System.Collections.Generic;

namespace MathematicalExpressionsCalculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO - Logging
            // TODO - Autofac
            Console.Write($"Hello, User!\n\nThis program is an arithmetic expression evaluator.\n" +
                $"It takes simple expressions and solves them with respect to the priority of operations.\n\n" +
                $"You have the following arithmetic operators available:\n\n\"+\" - addition\n\"-\" - subtraction\n" +
                $"\"*\" - multiplication\n\"/\" - division\n\"()\" - parentheses\n\nYou have the following input options available:\n\n" +
                $"- console input\n- txt-file input\n\nNOTE:\n\n- decimal separator is a point \".\"\n" +
                $"\n\nPlease enter txt-file location path or an expression: ");

            string userInput = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(userInput) == false)
            {
                if (new FileValidator(userInput).Validate())
                {
                    IRepository<IExpressionSubject> fileRepository = new FileRepository(userInput);
                    List<IExpressionSubject> fileExpressions = fileRepository.Get();

                    foreach (IExpressionSubject expression in fileExpressions)
                    {
                        var repositoryExpression = new ExpressionValidator(string.Join("", expression.InfixNotationValue));

                        if (repositoryExpression.Validate())
                        {
                            expression.Calculate();
                        }
                    }

                    fileRepository.Add();
                }
                else
                {
                    IRepository<IExpressionSubject> consoleRepository = new ConsoleRepository(userInput);
                    List<IExpressionSubject> consoleExpressions = consoleRepository.Get();

                    foreach (IExpressionSubject expression in consoleExpressions)
                    {
                        expression.Calculate();
                    }

                    consoleRepository.Add();
                }
            }
            else
            {
                Console.WriteLine("Empty input was given! Unable to proceed.");
            }
        }
    }
}
