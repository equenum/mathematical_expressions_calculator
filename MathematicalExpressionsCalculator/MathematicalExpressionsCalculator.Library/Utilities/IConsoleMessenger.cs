namespace MathematicalExpressionsCalculator.Library
{
    public interface IConsoleMessenger
    {
        void ConsoleRepoDoubleResultMessage(string[] infixExpression, string expressionResult);
        void ConsoleRepoIntegerResultMessage(string[] infixExpression, string expressionResult);
        void DivisionByZeroMessage();
        void EmptyInputMessage();
        void FileRepoResultMessage(string outputFilePath);
        void WelcomeMessage();
    }
}