namespace MathematicalExpressionsCalculator.Library.Validation
{
    /// <summary>
    /// Represents an expression validator.
    /// </summary>
    public interface IExpressionValidator
    {
        /// <summary>
        /// Represents an expression.
        /// </summary>
        string Expression { get; set; }
        /// <summary>
        /// Validates the expression.
        /// </summary>
        /// <returns>Validation result.</returns>
        bool Validate();
    }
}