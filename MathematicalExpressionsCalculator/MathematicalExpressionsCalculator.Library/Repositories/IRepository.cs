using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add();
        List<T> Get();
    }
}
