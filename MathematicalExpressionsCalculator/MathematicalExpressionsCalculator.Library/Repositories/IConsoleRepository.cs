using MathematicalExpressionsCalculator.Library.Observers;
using System.Collections.Generic;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    /// <summary>
    /// Represents a console repository.
    /// </summary>
    public interface IConsoleRepository : IRepository<IExpressionSubject>
    {
        /// <summary>
        /// Adds an expression to console repository store.
        /// </summary>
        /// <param name="userInput">Input expression value.</param>
        void AddExpressionToStore(string userInput);
    }
}