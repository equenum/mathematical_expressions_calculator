using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    /// <summary>
    /// Represents a generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Adds information to the reposiotory.
        /// </summary>
        void Add();
        /// <summary>
        /// Gets all data from the repository.
        /// </summary>
        /// <returns>All repository data.</returns>
        List<T> Get();
    }
}
