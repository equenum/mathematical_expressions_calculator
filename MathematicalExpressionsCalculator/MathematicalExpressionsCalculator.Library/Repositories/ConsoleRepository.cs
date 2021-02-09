using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public class ConsoleRepository : IConsoleRepository
    {
        private List<IExpressionSubject> _store = new List<IExpressionSubject>();

        public void Add()
        {
            foreach (IExpressionSubject element in _store)
            {
                if (double.TryParse(element.Result, out _))
                {
                    Console.WriteLine(String.Format("Result: {0} = {1:0.##}", string.Join("", element.InfixNotationValue), double.Parse(element.Result)));
                }
                else
                {
                    Console.WriteLine($"Result: {string.Join("", element.InfixNotationValue)} = {element.Result}");
                }
            }
        }

        public List<IExpressionSubject> Get()
        {
            return _store;
        }

        public void AddExpression(string userInput)
        {
            _store.Add(new ExpressionSubject(userInput));
        }
    }
}
