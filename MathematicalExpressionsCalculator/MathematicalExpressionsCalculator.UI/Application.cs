using MathematicalExpressionsCalculator.Library;
using MathematicalExpressionsCalculator.Library.Observers;
using MathematicalExpressionsCalculator.Library.Repositories;
using MathematicalExpressionsCalculator.Library.Utilities;
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
        private readonly IUserInputCatcher _userInputCatcher;

        public Application(IFileValidator fileValidator, IFileRepository fileRepository,
            IExpressionValidator expressionValidator, IConsoleRepository consoleRepository,
            IConsoleMessenger consoleMessenger, IUserInputCatcher userInputCatcher)
        {
            _fileValidator = fileValidator;
            _fileRepository = fileRepository;
            _expressionValidator = expressionValidator;
            _consoleRepository = consoleRepository;
            _consoleMessenger = consoleMessenger;
            _userInputCatcher = userInputCatcher;
        }

        public void Run()
        {
            Log.Information("Application was started.");
            _consoleMessenger.WelcomeMessage();

            string userInput = _userInputCatcher.Capture();

            if (string.IsNullOrEmpty(userInput) == false)
            {
                _fileValidator.FilePath = userInput;

                if (_fileValidator.Validate())
                {
                    Log.Information("User input is determined as a file path.");
                    _fileRepository.SetInputFilePath(userInput);
                    
                    List<IExpressionSubject> fileExpressions = _fileRepository.Get();
                    Log.Information("Input file was loaded.");

                    foreach (IExpressionSubject expression in fileExpressions)
                    {
                        _expressionValidator.Expression = string.Join("", expression.InfixNotationValue);

                        if (_expressionValidator.Validate())
                        {
                            expression.Calculate();
                        }
                    }

                    _fileRepository.Add();
                    Log.Information("Result was written to an output file.");
                }
                else
                {
                    Log.Information("User input was determined as an mathematical expression.");
                    _consoleRepository.AddExpression(userInput);

                    List<IExpressionSubject> consoleExpressions = _consoleRepository.Get();
                    Log.Information("Input expression was loaded.");

                    foreach (IExpressionSubject expression in consoleExpressions)
                    {
                        expression.Calculate();
                    }

                    _consoleRepository.Add();
                    Log.Information("Result was written to console.");
                }
            }
            else
            {
                _consoleMessenger.EmptyInputMessage();
                Log.Error("Empty input.");
            }

            Log.Information("Application was ended.");
        }
    }
}
