namespace MathematicalExpressionsCalculator.Library
{
    /// <summary>
    /// Represents a console messenger.
    /// </summary>
    public interface IConsoleMessenger
    {
        /// <summary>
        /// Displays a message to console that consist of a console repository expression calculation result (the result is double).
        /// </summary>
        /// <param name="infixExpression">Expression in infix notattion.</param>
        /// <param name="expressionResult">Expression calculation result.</param>
        void ConsoleRepoDoubleResultMessage(string[] infixExpression, string expressionResult);
        /// <summary>
        /// isplays a message to console that consist of a console repository expression calculation result (the result is integer).
        /// </summary>
        /// <param name="infixExpression">Expression in infix notattion.</param>
        /// <param name="expressionResult">Expression calculation result.</param>
        void ConsoleRepoIntegerResultMessage(string[] infixExpression, string expressionResult);
        /// <summary>
        /// Displays a message to console that the user has provided 
        /// an input expression that contains division by zero.
        /// </summary>
        void DivisionByZeroMessage();
        /// <summary>
        /// Displays a message to console that the user has provided 
        /// an empty input. 
        /// </summary>
        void EmptyInputMessage();
        /// <summary>
        /// Displays a message to console that of all of the file 
        /// repository expressions calculation results were 
        /// successfully written to output file.
        /// </summary>
        /// <param name="outputFilePath">Output file path.</param>
        void FileRepoResultMessage(string outputFilePath);
        /// <summary>
        /// Displays an application welcome message to console.
        /// The message contains information about all of the available
        /// application features and options.
        /// </summary>
        void WelcomeMessage();
    }
}