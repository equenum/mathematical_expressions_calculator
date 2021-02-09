namespace MathematicalExpressionsCalculator.Library.Validation
{
    public interface IExpressionValidator
    {
        string Expression { get; set; }

        bool Validate();
    }
}