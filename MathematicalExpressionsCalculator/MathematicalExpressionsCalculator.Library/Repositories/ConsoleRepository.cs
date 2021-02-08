using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public class ConsoleRepository : IRepository<IExpressionSubject>
    {
        public List<IExpressionSubject> Store { get; set; } = new List<IExpressionSubject>();

        public string UserInput { get; set; }

        public ConsoleRepository(string userInput)
        {
            UserInput = userInput;
        }

        public void Add()
        {
            foreach (IExpressionSubject element in Store)
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
            Store.Add(new ExpressionSubject(UserInput));

            return Store;
        }
    }
}
