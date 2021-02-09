using MathematicalExpressionsCalculator.Library;
using MathematicalExpressionsCalculator.Library.Observers;
using MathematicalExpressionsCalculator.Library.Repositories;
using MathematicalExpressionsCalculator.Library.Validation;
using Serilog;
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
        private readonly IConsoleMessenger _consoleMessenger;

        public Application(IFileValidator fileValidator, IFileRepository fileRepository,
            IExpressionValidator expressionValidator, IConsoleRepository consoleRepository,
            IConsoleMessenger consoleMessenger)
        {
            _fileValidator = fileValidator;
            _fileRepository = fileRepository;
            _expressionValidator = expressionValidator;
            _consoleRepository = consoleRepository;
            _consoleMessenger = consoleMessenger;
        }

        public void Run()
        {
            Log.Information("Application startup.");
            _consoleMessenger.WelcomeMessage();

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
                _consoleMessenger.EmptyInputMessage();
                Log.Error("Empty input.");
            }
        }
    }
}
