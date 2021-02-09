using MathematicalExpressionsCalculator.Library.Observers;
using MathematicalExpressionsCalculator.Library.Repositories;
using MathematicalExpressionsCalculator.Library.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UI
{
    public class Application : IApplication
    {
        private readonly IFileValidator _fileValidator;
        private readonly IFileRepository _fileRepository;
        private readonly IExpressionValidator _expressionValidator;
        private readonly IConsoleRepository _consoleRepository;

        public Application(IFileValidator fileValidator, IFileRepository fileRepository,
            IExpressionValidator expressionValidator, IConsoleRepository consoleRepository)
        {
            _fileValidator = fileValidator;
            _fileRepository = fileRepository;
            _expressionValidator = expressionValidator;
            _consoleRepository = consoleRepository;
        }

        public void Run()
        {
            Console.Write($"Hello, User!\n\nThis program is an arithmetic expression evaluator.\n" +
                $"It takes simple expressions and solves them with respect to the priority of operations.\n\n" +
                $"You have the following arithmetic operators available:\n\n\"+\" - addition\n\"-\" - subtraction\n" +
                $"\"*\" - multiplication\n\"/\" - division\n\"()\" - parentheses\n\nYou have the following input options available:\n\n" +
                $"- console input\n- txt-file input\n\nNOTE:\n\n- decimal separator is a point \".\"\n" +
                $"\n\nPlease enter txt-file location path or an expression: ");

            string userInput = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(userInput) == false)
            {
                _fileValidator.FilePath = userInput;

                if (_fileValidator.Validate())
                {
                    _fileRepository.SetInputFilePath(userInput);

                    List<IExpressionSubject> fileExpressions = _fileRepository.Get();

                    foreach (IExpressionSubject expression in fileExpressions)
                    {
                        _expressionValidator.Expression = string.Join("", expression.InfixNotationValue);

                        if (_expressionValidator.Validate())
                        {
                            expression.Calculate();
                        }
                    }

                    _fileRepository.Add();
                }
                else
                {
                    _consoleRepository.AddExpression(userInput);

                    List<IExpressionSubject> consoleExpressions = _consoleRepository.Get();

                    foreach (IExpressionSubject expression in consoleExpressions)
                    {
                        expression.Calculate();
                    }

                    _consoleRepository.Add();
                }
            }
            else
            {
                Console.WriteLine("Empty input was given! Unable to proceed.");
            }
        }
    }
}
