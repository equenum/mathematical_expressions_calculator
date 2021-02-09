using MathematicalExpressionsCalculator.Library.Observers;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public interface IFileRepository : IRepository<IExpressionSubject>
    {
        void SetInputFilePath(string inputFilePath);
    }
}