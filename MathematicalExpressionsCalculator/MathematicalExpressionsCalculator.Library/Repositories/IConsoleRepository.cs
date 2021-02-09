using MathematicalExpressionsCalculator.Library.Observers;
using System.Collections.Generic;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public interface IConsoleRepository : IRepository<IExpressionSubject>
    {
        void AddExpression(string userInput);
    }
}