using MathematicalExpressionsCalculator.Library.Observers;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    /// <summary>
    /// Represents a file repository.
    /// </summary>
    public interface IFileRepository : IRepository<IExpressionSubject>
    {
        /// <summary>
        /// Sets input file path. 
        /// </summary>
        /// <param name="inputFilePath">Input file path.</param>
        void SetInputFilePath(string inputFilePath);
    }
}