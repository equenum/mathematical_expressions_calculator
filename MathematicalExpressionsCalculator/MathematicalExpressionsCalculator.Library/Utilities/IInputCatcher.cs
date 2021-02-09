namespace MathematicalExpressionsCalculator.Library.Utilities
{
    /// <summary>
    /// Representa a user input catcher interface.
    /// </summary>
    public interface IInputCatcher
    {
        /// <summary>
        /// Captures user input value.
        /// </summary>
        /// <returns></returns>
        string Capture();
    }
}