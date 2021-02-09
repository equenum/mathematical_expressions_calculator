using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library
{
    /// <summary>
    /// Represents a console messenger.
    /// </summary>
    public class ConsoleMessenger : IConsoleMessenger
    {
        public void WelcomeMessage()
        {
            Console.Write($"Hello, User!\n\nThis program is an arithmetic expression evaluator.\n" +
                $"It takes simple expressions and solves them with respect to the priority of operations.\n\n" +
                $"You have the following arithmetic operators available:\n\n\"+\" - addition\n\"-\" - subtraction\n" +
                $"\"*\" - multiplication\n\"/\" - division\n\"()\" - parentheses\n\nYou have the following input options available:\n\n" +
                $"- console input\n- txt-file input\n\nNOTE:\n\n- decimal separator is a point \".\"\n" +
                $"\n\nPlease enter txt-file location path or an expression: ");
        }

        public void EmptyInputMessage()
        {
            Console.WriteLine("Empty input! Unable to proceed.");
        }

        public void ConsoleRepoDoubleResultMessage(string[] infixExpression, string expressionResult)
        {
            Console.WriteLine(String.Format("Result: {0} = {1:0.##}", string.Join("", infixExpression), double.Parse(expressionResult)));
        }

        public void ConsoleRepoIntegerResultMessage(string[] infixExpression, string expressionResult)
        {
            Console.WriteLine($"Result: {string.Join("", infixExpression)} = {expressionResult}");
        }

        public void FileRepoResultMessage(string outputFilePath)
        {
            Console.WriteLine($"Result has been written to output file ({outputFilePath}).");
        }

        public void DivisionByZeroMessage()
        {
            Console.WriteLine("Division by zero is not allowed!");
        }
    }
}
