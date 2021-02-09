namespace MathematicalExpressionsCalculator.Library.Validation
{
    /// <summary>
    /// Represents a file validator.
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Represents a file path of the target file. 
        /// </summary>
        string FilePath { get; set; }
        /// <summary>
        /// Validates the target file.
        /// </summary>
        /// <returns>Validation result.</returns>
        bool Validate();
    }
}