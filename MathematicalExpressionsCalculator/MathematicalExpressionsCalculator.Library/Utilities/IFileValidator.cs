namespace MathematicalExpressionsCalculator.Library.Validation
{
    public interface IFileValidator
    {
        string FilePath { get; set; }

        bool Validate();
    }
}